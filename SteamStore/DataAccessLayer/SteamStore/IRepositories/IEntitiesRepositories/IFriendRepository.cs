using DataAccessLayer.SteamStore.IRepositories.IBaseRepositories;
using DataAccessLayer.SteamStore.IRepositories.IBaseRepository;
using Entities.Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories
{
    public interface IFriendRepository : ICrudRepository<Friend>, IBaseSearchRepository<Friend>, ISearchByNameRepository<Friend>
    {
        Task<DataResponse<Friend>> GetFriendsByUserID(Guid userID);
    }
}
