using System;
using MailKit;
using MailKit.Net.Imap;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmailForms.BL.Abstractions;
using EmailForms.BL.Models;
using MailKit.Search;
using MimeKit;

namespace EmailForms.BL.Services
{
    public class ImapService : IImapService
    {
        private const int ImapPort = 993;

        public async Task<MimeMessage> GetMessage(MailDto mailDto, bool useSsl, UniqueId emailId)
        {
            using (var imapClient = new ImapClient())
            {
                imapClient.CheckCertificateRevocation = false;
                await imapClient.ConnectAsync(mailDto.Server, ImapPort, useSsl);
                await imapClient.AuthenticateAsync(mailDto.Name, mailDto.Password);

                var inbox = imapClient.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadOnly);
                return await inbox.GetMessageAsync(emailId);
            }
        }

        public async Task<IEnumerable<IMessageSummary>> GetAllSubjects(MailDto mailDto, bool useSsl)
        {
            using (var imapClient = new ImapClient())
            {
                imapClient.CheckCertificateRevocation = false;
                await imapClient.ConnectAsync(mailDto.Server, ImapPort, useSsl);
                await imapClient.AuthenticateAsync(mailDto.Name, mailDto.Password);

                var inbox = imapClient.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadOnly);
                return await inbox.FetchAsync(0, -1, MessageSummaryItems.Full | MessageSummaryItems.UniqueId);
            }
        }

        public async Task<string> ValidateCredentials(MailCreateDto mailCreateDto)
        {
            try
            {
                using (var imapClient = new ImapClient())
                {
                    imapClient.CheckCertificateRevocation = false;
                    await imapClient.ConnectAsync(mailCreateDto.Server, ImapPort, true);
                    await imapClient.AuthenticateAsync(mailCreateDto.Name, mailCreateDto.Password);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return default;
        }
    }
}
