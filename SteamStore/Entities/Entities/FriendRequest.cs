using Entities.FatherEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class FriendRequest : Entity
    {
        public FriendRequest()
        {

        }

        public FriendRequest(Guid requestUserID, Guid forUserID)
        {
            RequestUserID = requestUserID;
            ForUserID = forUserID;
        }

        public Guid RequestUserID { get; private set; }
        public virtual User RequestUser { get; private set; }
        public Guid ForUserID { get; private set; }
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
