using JwtAuthentication.Logic.Common.Models;
namespace JwtAuthentication.Logic.Common.Services
{
    public interface ITokenService
    {
        string GenerateToken(UserBLL user);
    }
}