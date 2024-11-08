using AutoMapper;
using Marketplace.DataAccess.Common.Helpers;
using Marketplace.DataAccess.Common.Models;
using Marketplace.DataAccess.Common.Repositories;
using Marketplace.Logic.Common.Models;
using Marketplace.Logic.Common.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketplace.Logic.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CarBLL>> AddAsync(CarBLL car)
        {
            var carDb = _mapper.Map<CarDb>(car);

            var addResult = await _repository.AddAsync(carDb);
            if (addResult.Success)
            {
                var carBLL = _mapper.Map<CarBLL>(addResult.Data);
                return Result<CarBLL>.Ok(carBLL);
            }
            else
            {
                return Result<CarBLL>.Fail(addResult.Message);
            }
        }

        public async Task<Result<CarBLL>> UpdateAsync(CarBLL car)
        {
            var carDb = _mapper.Map<CarDb>(car);

            var updateResult = await _repository.UpdateAsync(carDb);
            if (updateResult.Success)
            {
                var carBLL = _mapper.Map<CarBLL>(updateResult.Data);
                return Result<CarBLL>.Ok(carBLL);
            }
            else
            {
                return Result<CarBLL>.Fail(updateResult.Message);
            }
        }

        public async Task<Result<CarBLL>> DeleteAsync(int id)
        {
            var carDb = await _repository.GetByIdAsync(id);

            if (carDb == null)
            {
                return Result<CarBLL>.Fail("There is no car with id = " + id);
            }

            var deleteResult = await _repository.DeleteAsync(carDb);
            if (deleteResult.Success)
            {
                var carBLL = _mapper.Map<CarBLL>(deleteResult.Data);
                return Result<CarBLL>.Ok(carBLL);
            }
            else
            {
                return Result<CarBLL>.Fail(deleteResult.Message);
            }
        }

        public async Task<IEnumerable<CarBLL>> GetAllAsync()
        {
            return await _repository.GetAllAsync()
                .ContinueWith(result => _mapper.Map<IEnumerable<CarBLL>>(result.Result));
        }

        public async Task<CarBLL> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id)
                .ContinueWith(result => _mapper.Map<CarBLL>(result.Result));
        }
    }
}