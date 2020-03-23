using BussinessLogicalLayer.Validates.Interface;
using Entities.Entities;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicalLayer.Validates
{
    public class ItemValidate : Item, IBaseValidate<Item>
    {
        public IReadOnlyCollection<Notification> ValidateObjectToCreat(Item objectToValidate)
        {
            Contract ValidatingItem = new Contract()
            .Requires()
            .HasMinLen(objectToValidate.Name, 1, "Item.Name", "O nome do item não pode ser nulo");

            return ValidatingItem.Notifications;
        }
    }
}
