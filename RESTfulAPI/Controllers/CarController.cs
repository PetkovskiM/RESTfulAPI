using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RESTfulAPI.Data;
using RESTfulAPI.IRepository;
using RESTfulAPI.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RESTfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CarController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCars([FromQuery] RequestParams requestParams)
        {
            var cars = await _unitOfWork.Cars.GetPagedList(requestParams);
            var results = _mapper.Map<IList<CarDTO>>(cars);
            return Ok(results);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCarByName(string name)
        {
            var cars = await _unitOfWork.Cars.GetAll(c => c.Car.Contains($"{name}"));
            var results = _mapper.Map<IList<CarDTO>>(cars);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetCar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _unitOfWork.Cars.Get(q => q.Id == id);
            var result = _mapper.Map<CarDTO>(car);
            return Ok(result);
        }

       // [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarDTO carDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Something Went Wrong in the {nameof(CreateCar)}");
                return BadRequest(ModelState);
            }
            var car = _mapper.Map<CarModel>(carDTO);
            await _unitOfWork.Cars.Insert(car);
            await _unitOfWork.Save();
            return CreatedAtRoute("GetCar", new { id = car.Id }, car);
        }

       // [Authorize(Roles = "Administrator")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] UpdateCarDTO carDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCar)}");
                return BadRequest(ModelState);
            }

            var car = await _unitOfWork.Cars.Get(q => q.Id == id);
            if (car == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCar)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(carDTO,car);
            _unitOfWork.Cars.Update(car);
            await _unitOfWork.Save();
            return NoContent();
        }

        //[Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCar)}");
                return BadRequest();
            }

            var car = await _unitOfWork.Cars.Get(q => q.Id == id);
            if (car == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCar)}");
                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.Cars.Delete(id);
            await _unitOfWork.Save();

            return NoContent();

        }

    }
}
