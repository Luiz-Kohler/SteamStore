using Entities.FatherEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class FriendRequest : Entity
    {
        public FriendRequest(int requestUserID, int forUserID)
        {
            RequestUserID = requestUserID;
            ForUserID = forUserID;
        }

        public int RequestUserID { get; private set; }
        public virtual User RequestUser { get; private set; }
        public int ForUserID { get; private set; }
        public virtual User ForUser { get; private set; }

        public void GetRequestUser(User requestUser)
        {
            this.RequestUser = requestUser;
        }

        public void GetForUser(User forUser)
        {
            this.ForUser = forUser;
        }
    }
}
