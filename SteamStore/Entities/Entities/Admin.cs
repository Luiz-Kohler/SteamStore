using Entities.FatherEntity;
using Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Admin : Entity
    {
        public string Name { get; set; }
        public Login Login { get; set; } 
        public DateTime BornDate { get; set; }
    }
}
