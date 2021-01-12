using System;
using System.Collections;
using System.Collections.Generic;

namespace EmailForms.Core
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Mail> Mails { get; set; } = new List<Mail>();
    }
}
