using System;
using System.Collections.Generic;
using MailKit;

namespace EmailForms.BL.Models
{
    public class MailDto
    {
        public Guid Id { get; set; }
        public string Server { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsSelected { get; set; } = true;

        public ICollection<MailMessage> Messages { get; set; } = new List<MailMessage>();
    }
}
