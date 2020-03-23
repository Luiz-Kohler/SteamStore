using DataAccessLayer.SteamStore.IRepositories.IBaseRepositories;
using DataAccessLayer.SteamStore.IRepositories.IBaseRepository;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories
{
    public interface ICommentRepositoy : ICrudRepository<Comment>, IBaseSearchRepository<Comment>, ISearchByNameRepository<Comment>
    {
    }
}
