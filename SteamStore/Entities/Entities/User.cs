using Entities.FatherEntity;
using Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Entities.Entities
{
    public class User : Entity
    {

        private List<Item> _items;
        private List<Sale> _sales;
        private List<Ad> _ads;
        private List<Comment> _mycomments;
        private List<Comment> _forMecomments;
        private List<Friend> _friends;
        private List<FriendRequest> _myFriendRequest;
        private List<FriendRequest> _forMeFriendRequest;


        public User()
        {

        }

        public User(string nick, Login login, DateTime bornDate)
        {
            Nick = nick;
            Login = login;
            BornDate = bornDate;
            Cash = 0;

            _items = new List<Item>();
            _sales = new List<Sale>();
            _ads = new List<Ad>();
            _mycomments = new List<Comment>();
            _forMecomments = new List<Comment>();
            _friends = new List<Friend>();
            _myFriendRequest = new List<FriendRequest>();
            _forMeFriendRequest = new List<FriendRequest>();
        }

        public string Nick { get; private set; }
        public Login Login { get; private set; }
        public DateTime BornDate { get; private set; }
        public decimal Cash { get; private set; }
        public virtual IReadOnlyCollection<Item> Items { get { return _items.ToList(); } }
        public virtual IReadOnlyCollection<Sale> Sales { get { return _sales.ToList(); } }
        public virtual IReadOnlyCollection<Ad> Ads { get { return _ads.ToList(); } }
        public virtual IReadOnlyCollection<Comment> MyComments { get { return _mycomments.ToList(); } }
        public virtual IReadOnlyCollection<Comment> ForMeComments { get { return _forMecomments.ToList(); } }
        public virtual IReadOnlyCollection<Friend> Friends { get { return _friends.ToList(); } }
        public virtual IReadOnlyCollection<FriendRequest> MyFriendRequest { get { return _myFriendRequest.ToList(); } }
        public virtual IReadOnlyCollection<FriendRequest> ForMeFriendRequest { get { return _forMeFriendRequest.ToList(); } }

        public void InsertCash(decimal cash)
        {
            this.Cash = cash;
        }

        public void ChangeNick(string nick)
        {
            nick = nick.ToLower().Trim();
            nick = Regex.Replace(nick, @"\s+", " ");
            this.Nick = nick;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }
        public void GetAllItem(List<Item> items)
        {
            this._items = items;
        }

        public void AddSale(Sale sale)
        {
            _sales.Add(sale);
        }

        public void GetAllItem(List<Sale> sales)
        {
            this._sales = sales;
        }

        public void AddAd(Ad ad)
        {
            _ads.Add(ad);
        }

        public void GetAllAd(List<Ad> ads)
        {
            this._ads = ads;
        }

        public void AddMyComment(Comment comment)
        {
            _mycomments.Add(comment);
        }

        public void GetAllMyComments(List<Comment> comments)
        {
            this._mycomments = comments;
        }

        public void AddForMeComment(Comment comment)
        {
            _forMecomments.Add(comment);
        }

        public void GetAllAddForMeComments(List<Comment> comments)
        {
            this._forMecomments = comments;
        }

        public void AddFriends(Friend friend)
        {
            _friends.Add(friend);
        }

        public void GetAllFriends(List<Friend> friends)
        {
            this._friends = friends;
        }

        public void AddMyFriendRequest(FriendRequest friendRequest)
        {
            _myFriendRequest.Add(friendRequest);
        }

        public void GetAllMyFriendRequests(List<FriendRequest> friendRequests)
        {
            this._myFriendRequest = friendRequests;
        }

        public void AddForMeFriendRequest(FriendRequest friendRequest)
        {
            _forMeFriendRequest.Add(friendRequest);
        }

        public void GetAllMeFriendRequests(List<FriendRequest> friendRequests)
        {
            this._forMeFriendRequest = friendRequests;
        }
    }
}
