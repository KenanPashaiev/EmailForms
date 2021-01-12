using System;
using MailKit;

namespace EmailForms.BL.Models
{
    public class MailMessage
    {
        public UniqueId Id { get; set; }
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public Guid MailId { get; set; }
    }
}
