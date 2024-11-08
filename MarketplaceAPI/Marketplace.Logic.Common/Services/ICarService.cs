using Marketplace.DataAccess.Common.Helpers;
using Marketplace.Logic.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketplace.Logic.Common.Services
{
    public interface ICarService
    {
        Task<Result<CarBLL>> AddAsync(CarBLL car);
        Task<Result<CarBLL>> UpdateAsync(CarBLL car);
        Task<Result<CarBLL>> DeleteAsync(int id);
        Task<IEnumerable<CarBLL>> GetAllAsync();
        Task<CarBLL> GetByIdAsync(int id);
    }
}