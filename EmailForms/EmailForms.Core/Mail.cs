using System;

namespace EmailForms.Core
{
    public class Mail
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string EncryptedServer { get; set; }
        public string EncryptedName { get; set; }
        public string EncryptedPassword { get; set; }
    }
}
