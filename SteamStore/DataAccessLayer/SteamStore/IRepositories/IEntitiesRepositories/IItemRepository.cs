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
    public interface IItemRepository : ICrudRepository<Item>, IBaseSearchRepository<Item>, ISearchByNameRepository<Item>
    {
        Task<DataResponse<Item>> GetItemsUserID(Guid userID);
        Task<Response> ChangeOwner(Guid newUserOwnerID, Guid itemID);
    }
}
