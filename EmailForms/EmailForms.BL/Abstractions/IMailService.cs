using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmailForms.BL.Models;

namespace EmailForms.BL.Abstractions
{
    public interface IMailService
    {
        Task<List<MailDto>> GetAllMailsForUser(string username);
        Task<bool> DeleteMail(Guid mailId);
        Task<bool> AddMail(string username, MailCreateDto mailDto);
    }
}
