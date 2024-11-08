using Marketplace.DataAccess.Common.Helpers;
using Marketplace.DataAccess.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketplace.DataAccess.Common.Repositories
{
    public interface ICarRepository
    {
        Task<Result<CarDb>> AddAsync(CarDb car);
        Task<Result<CarDb>> UpdateAsync(CarDb car);
        Task<Result<CarDb>> DeleteAsync(CarDb car); 
        Task<IEnumerable<CarDb>> GetAllAsync();
        Task<CarDb> GetByIdAsync(int id);
    }
}