using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ValueObject
{
    public class Login
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void ChangePassword(string password)
        {
            this.Password = password;
        }
    }
}
