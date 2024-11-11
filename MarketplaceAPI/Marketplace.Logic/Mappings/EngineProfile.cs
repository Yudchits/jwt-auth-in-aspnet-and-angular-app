using AutoMapper;
using Marketplace.DataAccess.Common.Models;
using Marketplace.Logic.Common.Models;

namespace Marketplace.Logic.Mappings
{
    public class EngineProfile : Profile
    {
        public EngineProfile()
        {
            CreateMap<EngineBLL, EngineDb>();
            CreateMap<EngineDb, EngineBLL>();
        }
    }
}