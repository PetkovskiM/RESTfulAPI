using System;
using System.ComponentModel.DataAnnotations;

namespace RESTfulAPI.Models
{
    public class CreateCarDTO
    {
       
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Car Name Is Too Long")]
        public string Car { get; set; }
        public float MPG { get; set; }
        public int Cylinders { get; set; }
        public int Horsepower { get; set; }
        public string Weight { get; set; }
        public double Acceleration { get; set; }
        public int Model { get; set; }
        public string Origin { get; set; }
        
    }

    public class UpdateCarDTO:CreateCarDTO
    {

    }

    public class CarDTO:CreateCarDTO
    {
        public int Id { get; set; }
        public double LitersPerHundredKm
        {
            get
            {
                return Math.Round(235.215 / MPG, 2);
            }
        }

    }
 }

