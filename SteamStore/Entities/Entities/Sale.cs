using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Sale
    {
        public DateTime DateSell { get; private set; }
        public int BuyerId { get; private set; }
        public virtual User Buyer { get; private set; }
        public int AdId { get; private set; }
        public virtual Ad Ad { get; private set; }
    }
}
