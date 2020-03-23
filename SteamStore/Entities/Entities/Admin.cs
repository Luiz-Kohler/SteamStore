using Entities.FatherEntity;
using Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Admin : Entity
    {
        public Admin()
        {

        }
        public Admin(string name, Login login, DateTime bornDate)
        {
            Name = name;
            Login = login;
            BornDate = bornDate;
        }

        public string Name { get; private set; }
        public Login Login { get; private set; } 
        public DateTime BornDate { get; private set; }
    }
}
