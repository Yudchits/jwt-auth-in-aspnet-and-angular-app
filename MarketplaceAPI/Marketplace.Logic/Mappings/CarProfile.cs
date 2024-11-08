using AutoMapper;
using Marketplace.DataAccess.Common.Models;
using Marketplace.Logic.Common.Models;

namespace Marketplace.Logic.Mappings
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarBLL, CarDb>();
            CreateMap<CarDb, CarBLL>();
        }
    }
}