﻿using Entities.FatherEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Item : Entity
    {
        public string Name { get; private set; }
        public int UserID { get; private set; }
        public virtual User User { get; private set; }
    }
}