using Entities.FatherEntity;
using Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class User : Entity
    {
        public string Nick { get; private set; }
        public Login Login { get; set; }
        public DateTime BornDate { get; private set; }
        public decimal Cash { get; private set; }
        public virtual IList<Item> Items { get; set; }
        public virtual IList<Sale> Sales { get; set; }
        public virtual IList<Ad> Ads { get; set; }
        public virtual IList<Comment> MyComments { get; set; }
        public virtual IList<Comment> ForMeComments { get; set; }
        public virtual IList<Friend> Friends { get; set; }
        public virtual IList<FriendRequest> MyFriendRequest { get; set; }
        public virtual IList<FriendRequest> ForMeFriendRequest { get; set; }
    }
}
