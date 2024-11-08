using Marketplace.Logic.Common.Models;
using Marketplace.Logic.Common.Services;
using Marketplace.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.WebAPI.Controllers
{
    [ApiController]
    [Route("api/car")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync([FromBody] CarBLL car)
        {
            var addResult = await _carService.AddAsync(car);

            if (addResult.Success)
            {
                return StatusCode(200, new { Data = addResult?.Data.Id });
            }
            else
            {
                return StatusCode(400, new { Message = addResult.Message });
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] CarBLL car)
        {
            var updateResult = await _carService.UpdateAsync(car);

            if (updateResult.Success)
            {
                return StatusCode(200, new { Data = updateResult?.Data.Id });
            }
            else
            {
                return StatusCode(400, new { Message = updateResult.Message });
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] CarDeletePL car)
        {
            var deleteResult = await _carService.DeleteAsync(car.Id);

            if (deleteResult.Success)
            {
                return StatusCode(200, new { Data = deleteResult?.Data.Id });
            }
            else
            {
                return StatusCode(400, new { Message = deleteResult.Message });
            }
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var cars = await _carService.GetAllAsync();

            if (!cars.Any())
            {
                return StatusCode(204);
            }

            return StatusCode(200, new { Data = cars });
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
        {
            var carById = await _carService.GetByIdAsync(id);

            if (carById == null)
            {
                return StatusCode(404, new { Message = "There is no car with id = " + id });
            }

            return StatusCode(200, new { Data = carById });
        }
    }
}