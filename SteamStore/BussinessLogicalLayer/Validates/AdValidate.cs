using BussinessLogicalLayer.Validates.Interface;
using Entities.Entities;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicalLayer.Validates
{
    public class AdValidate : IBaseValidate<Ad>
    {
        public IReadOnlyCollection<Notification> ValidateObjectToCreat(Ad objectToValidate)
        {
            Contract ValidatingAd = new Contract()
            .Requires()
            .IsGreaterOrEqualsThan(objectToValidate.Price, 0, "Ad.Price", "O anuncio não pode ter um preço 0 ou menos");
            return ValidatingAd.Notifications;
        }
    }
}
