using Entities.FatherEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Entities.Entities
{
    public class Item : Entity
    {

        public Item()
        {

        }
        public Item(string name, Guid userID)
        {
            Name = name;
            UserID = userID;
        }

        public string Name { get; private set; }
        public Guid UserID { get; private set; }
        public virtual User User { get; private set; }

        public void GetUser(User user)
        {
            this.User = user;
        }

        public void ChangeName(string name)
        {
            name = name.ToLower().Trim();
            name = Regex.Replace(name, @"\s+", " ");

            this.Name = name;
        }
    }
}
