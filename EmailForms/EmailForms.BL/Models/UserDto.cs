using System.Collections.Generic;

namespace EmailForms.BL.Models
{
    public class UserDto
    {
        public string Username { get; set; }
        public ICollection<MailDto> Mails { get; set; }
    }
}
