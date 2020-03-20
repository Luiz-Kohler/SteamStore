using Entities.FatherEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Friend : Entity
    {
        public Friend(int userID, int friendUserID)
        {
            UserID = userID;
            FriendUserID = friendUserID;
        }

        public int UserID { get; private set; }
        public User User { get; private set; }
        public int FriendUserID { get; private set; }
        public User FriendUser { get; private set; }

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
