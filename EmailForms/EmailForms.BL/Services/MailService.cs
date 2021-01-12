using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailForms.BL.Abstractions;
using EmailForms.BL.Models;
using EmailForms.BL.Utility;
using EmailForms.Core;
using EmailForms.DAL;

namespace EmailForms.BL.Services
{
    public class MailService : IMailService
    {
        private readonly UserRepository _userRepository;
        private readonly MailRepository _mailRepository;

        public MailService(UserRepository userRepository, MailRepository mailRepository)
        {
            _userRepository = userRepository;
            _mailRepository = mailRepository;
        }

        public async Task<List<MailDto>> GetAllMailsForUser(string username)
        {
            var user = await _userRepository.Get(username);
            if (user == default)
            {
                return default;
            }

            var mails = (await _mailRepository.GetAll(user.UserId)).Select(mail => new MailDto
            {
                Id = mail.Id,
                Server = StringEncryptor.Decrypt(mail.EncryptedServer, user.PasswordHash),
                Name = StringEncryptor.Decrypt(mail.EncryptedName, user.PasswordHash),
                Password = StringEncryptor.Decrypt(mail.EncryptedPassword, user.PasswordHash)
            });
            return mails.ToList();
        }

        public async Task<bool> DeleteMail(Guid mailId)
        {
            var mail = await _mailRepository.Get(mailId);
            if (mail == default)
            {
                return false;
            }

            await _mailRepository.Delete(mailId);
            return true;
        }

        public async Task<bool> AddMail(string username, MailCreateDto mailDto)
        {
            var user = await _userRepository.Get(username);
            if(user == default)
            {
                return false;
            }

            var mailName = StringEncryptor.Encrypt(mailDto.Name, user.PasswordHash); 
            var mailServer = StringEncryptor.Encrypt(mailDto.Server, user.PasswordHash); 
            var mailPassword = StringEncryptor.Encrypt(mailDto.Password, user.PasswordHash);
            var mail = new Mail { EncryptedName = mailName, EncryptedServer = mailServer, EncryptedPassword = mailPassword };
            await _mailRepository.Create(user.UserId, mail);

            return true;
        }
    }
}
