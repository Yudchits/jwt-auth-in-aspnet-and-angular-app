using AutoMapper;
using JwtAuthentication.DataAccess.Common.Models;
using JwtAuthentication.Logic.Common.Models;

namespace JwtAuthentication.Logic.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleBLL, RoleDb>();
            CreateMap<RoleDb, RoleBLL>();
        }
    }
}