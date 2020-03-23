using DataAccessLayer.SteamStore.IRepositories.IBaseRepositories;
using DataAccessLayer.SteamStore.IRepositories.IBaseRepository;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories
{
    public interface IFriendRequestRepository : ICrudRepository<FriendRequest>, IBaseSearchRepository<FriendRequest>
    {
        Task<List<FriendRequest>> GetFriedsRequestByUserID(Guid userID);
    }
}
