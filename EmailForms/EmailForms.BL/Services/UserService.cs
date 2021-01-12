using System;
using System.Threading.Tasks;
using EmailForms.BL.Abstractions;
using EmailForms.BL.Models;
using EmailForms.BL.Utility;
using EmailForms.Core;
using EmailForms.DAL;

namespace EmailForms.BL.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMailService _mailService;

        public UserService(UserRepository userRepository, IMailService mailService)
        {
            _userRepository = userRepository;
            _mailService = mailService;
        }

        public async Task<UserDto> LogIn(UserLoginDto userLoginDto)
        {
            var existingUser = await _userRepository.Get(userLoginDto.Username);
            if (existingUser == default || !PasswordHasher.Verify(userLoginDto.Password, existingUser.PasswordHash))
            {
                return default;
            }

            var mails = await _mailService.GetAllMailsForUser(existingUser.Username);

            return new UserDto
            {
                Username = existingUser.Username,
                Mails = mails
            };
        }

        public async Task<bool> Register(UserLoginDto userLoginDto)
        {
            var existingUser = await _userRepository.Get(userLoginDto.Username);
            if(existingUser != default)
            {
                return false;
            }

            var user = new User
            {
                UserId = Guid.NewGuid(),
                Username = userLoginDto.Username,
                PasswordHash = PasswordHasher.Hash(userLoginDto.Password)
            };

            await _userRepository.Create(user);
            return true;
        }
    }
}
