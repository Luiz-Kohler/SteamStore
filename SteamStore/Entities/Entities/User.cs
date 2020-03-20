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
        public Login Login { get; private set; }
        public DateTime BornDate { get; private set; }
        public decimal Cash { get; private set; }
        public virtual IReadOnlyCollection<Item> Items { get; private set; }
        public virtual IReadOnlyCollection<Sale> Sales { get; private set; }
        public virtual IReadOnlyCollection<Ad> Ads { get; private set; }
        public virtual IReadOnlyCollection<Comment> MyComments { get; private set; }
        public virtual IReadOnlyCollection<Comment> ForMeComments { get; private set; }
        public virtual IReadOnlyCollection<Friend> Friends { get; private set; }
        public virtual IReadOnlyCollection<FriendRequest> MyFriendRequest { get; private set; }
        public virtual IReadOnlyCollection<FriendRequest> ForMeFriendRequest { get; private set; }
    }
}
