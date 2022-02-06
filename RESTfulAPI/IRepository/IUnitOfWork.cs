using RESTfulAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulAPI.IRepository
{
   public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<CarModel> Cars { get; }
        Task Save();
    }
}
