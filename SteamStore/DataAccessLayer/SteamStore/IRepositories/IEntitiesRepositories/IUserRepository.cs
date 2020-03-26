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
    public interface IUserRepository : ICrudRepository<User>, IBaseSearchRepository<User>, ISearchByNameRepository<User>, IAuthentication<User>
    {
        Task<DataResponse<User>> GetUserByIdForProfile(Guid userID, bool owenr);
    }
}
