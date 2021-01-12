using System.Threading.Tasks;
using EmailForms.BL.Models;

namespace EmailForms.BL.Abstractions
{
    public interface IUserService
    {
        Task<UserDto> LogIn(UserLoginDto userLoginDto);
        Task<bool> Register(UserLoginDto userLoginDto);
    }
}
