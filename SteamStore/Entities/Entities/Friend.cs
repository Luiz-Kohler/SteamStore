using Entities.FatherEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Friend : Entity
    {

        public Friend()
        {

        }
        public Friend(Guid userID, Guid friendUserID)
        {
            UserID = userID;
            FriendUserID = friendUserID;
        }

        public Guid UserID { get; private set; }
        public virtual User User { get; private set; }
        public Guid FriendUserID { get; private set; }
        public virtual User FriendUser { get; private set; }

        public void GetUser(User user)
        {
            this.User = user;
        }

        public void GetFriendUser(User friendUser)
        {
            this.FriendUser = friendUser;
        }
    }
}
