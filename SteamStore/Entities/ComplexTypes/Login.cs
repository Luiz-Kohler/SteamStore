using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.ComplexTypes
{
    [ComplexType]
    public class Login
    {

        public Login(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }

        public void ChangePassword(string password)
        {
            this.Password = password;
        }
    }
}
