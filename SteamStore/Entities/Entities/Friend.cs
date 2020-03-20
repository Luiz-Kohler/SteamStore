using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Friend
    {
        public int UserID { get; private set; }
        public User User { get; private set; }
        public int FriendUserID { get; private set; }
        public User FriendUser { get; private set; }
    }
}
