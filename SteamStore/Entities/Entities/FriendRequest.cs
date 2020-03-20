using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class FriendRequest
    {
        public int RequestUserID { get; private set; }
        public virtual User RequestUser { get; private set; }

        public int ForUserID { get; private set; }
        public virtual User ForUser { get; private set; }
    }
}
