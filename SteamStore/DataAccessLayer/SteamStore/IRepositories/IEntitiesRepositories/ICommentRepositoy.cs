using DataAccessLayer.SteamStore.IRepositories.IBaseRepositories;
using DataAccessLayer.SteamStore.IRepositories.IBaseRepository;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories
{
    public interface ICommentRepositoy : ICrudRepository<Comment>, IBaseSearchRepository<Comment>
    {
        Task<List<Comment>> GetCommentsByWritterID(Guid writterID);
        Task<List<Comment>> GetCommentsByForUserID(Guid forUserID);
    }
}
