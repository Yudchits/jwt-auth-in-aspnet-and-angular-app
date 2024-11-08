using AutoMapper;
using JwtAuthentication.DataAccess.Common.Models;
using JwtAuthentication.Logic.Common.Models;

namespace JwtAuthentication.Logic.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserBLL, UserDb>();
            CreateMap<UserDb, UserBLL>();
        }
    }
}