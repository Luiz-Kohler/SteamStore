using Entities.FatherEntity;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

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

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(name, 1, "Item.Name", "O nome do item não pode ser nulo"));

            UserID = userID;
        }

        public string Name { get; private set; }
        public Guid UserID { get; private set; }
        public virtual User User { get; private set; }

        public void GetUser(User user)
        {
            this.User = user;
        }
    }
}
