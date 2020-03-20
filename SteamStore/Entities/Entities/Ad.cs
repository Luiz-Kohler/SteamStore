using Entities.FatherEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Ad : Entity
    {
        public decimal Price { get; private set; }
        public DateTime DateAd { get; private set; }
        public int ItemID { get; private set; }
        public virtual Item Item { get; private set; }
        public int SellerUserID { get; private set; }
        public virtual User SellerUser { get; private set; }
        public int? SaleID { get; private set; }
        public virtual Sale Sale { get; private set; }
        public bool IsSold { get; private set; }
    }
}
