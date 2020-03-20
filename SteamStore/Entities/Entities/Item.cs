using Entities.FatherEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Item : Entity
    {
        public Item(string name, int userID)
        {
            Name = name;
            UserID = userID;
        }

        public string Name { get; private set; }
        public int UserID { get; private set; }
        public virtual User User { get; private set; }

    }
}
