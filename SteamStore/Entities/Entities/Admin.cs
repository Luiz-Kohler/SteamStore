using Entities.FatherEntity;
using Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Admin : Entity
    {
        public string Name { get; private set; }
        public Login Login { get; private set; } 
        public DateTime BornDate { get; private set; }
    }
}
