using Entities.FatherEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Sale : Entity
    {
        public Sale(int buyerId, int adId,)
        {
            DateSell = DateTime.UtcNow;
            BuyerId = buyerId;
            AdId = adId;
        }

        public DateTime DateSell { get; private set; }
        public int BuyerId { get; private set; }
        public virtual User Buyer { get; private set; }
        public int AdId { get; private set; }
        public virtual Ad Ad { get; private set; }
    }
}
