using AutoMapper;
using JwtAuthentication.DataAccess.Common.Models;
using JwtAuthentication.Logic.Common.Models;

namespace JwtAuthentication.Logic.Mappings
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRoleBLL, UserRoleDb>();
            CreateMap<UserRoleDb, UserRoleBLL>();
        }
    }
}