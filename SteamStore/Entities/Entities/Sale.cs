using Entities.FatherEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Sale : Entity
    {
        public Sale()
        {

        }
        public Sale(Guid buyerId, Guid adId)
        {
            DateSell = DateTime.UtcNow;
            BuyerId = buyerId;
            AdId = adId;
        }

        public DateTime DateSell { get; private set; }
        public Guid BuyerId { get; private set; }
        public virtual User Buyer { get; private set; }
        public Guid AdId { get; private set; }
        public virtual Ad Ad { get; private set; }

        public void GetUserBuyer(User userBuyer)
        {
            this.Buyer = userBuyer;
        }

        public void GetAd(Ad ad)
        {
            this.Ad = ad;
        }
    }
}
