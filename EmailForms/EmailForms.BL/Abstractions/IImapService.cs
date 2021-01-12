using System.Collections.Generic;
using System.Threading.Tasks;
using EmailForms.BL.Models;
using MailKit;
using MimeKit;

namespace EmailForms.BL.Abstractions
{
    public interface IImapService
    {
        Task<MimeMessage> GetMessage(MailDto mailDto, bool useSsl, UniqueId emailId);
        Task<IEnumerable<IMessageSummary>> GetAllSubjects(MailDto mailDto, bool useSsl);
        Task<string> ValidateCredentials(MailCreateDto mailCreateDto);
    }
}
