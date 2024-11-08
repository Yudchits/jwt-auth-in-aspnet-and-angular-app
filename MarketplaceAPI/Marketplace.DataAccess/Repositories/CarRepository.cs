using Marketplace.DataAccess.Common.Helpers;
using Marketplace.DataAccess.Common.Models;
using Marketplace.DataAccess.Common.Repositories;
using Marketplace.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketplace.DataAccess.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly MarketplaceContext _context;

        public CarRepository(MarketplaceContext context)
        {
            _context = context;
        }

        public async Task<Result<CarDb>> AddAsync(CarDb car)
        {
            _context.Cars.Add(car);
            var isAdded = await SaveChangesAsync();
            if (isAdded)
            {
                return Result<CarDb>.Ok(car);
            }
            else
            {
                return Result<CarDb>.Fail("The car wasn't added. Try later");
            }
        }

        public async Task<Result<CarDb>> UpdateAsync(CarDb car)
        {
            _context.Cars.Update(car);
            var isUpdated = await SaveChangesAsync();
            if (isUpdated)
            {
                return Result<CarDb>.Ok(car);
            }
            else
            {
                return Result<CarDb>.Fail("The car wasn't updated. Try later");
            }
        }

        public async Task<Result<CarDb>> DeleteAsync(CarDb car)
        {
            _context.Cars.Remove(car);
            var isDeleted = await SaveChangesAsync();
            if (isDeleted)
            {
                return Result<CarDb>.Ok(car);
            }
            else
            {
                return Result<CarDb>.Fail("The car wasn't deleted. Try later");
            }
        }

        public async Task<IEnumerable<CarDb>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<CarDb> GetByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        private async Task<bool> SaveChangesAsync()
        {
            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}
