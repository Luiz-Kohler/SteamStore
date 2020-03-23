using DataAccessLayer.SteamStore.IRepositories.IBaseRepositories;
using DataAccessLayer.SteamStore.IRepositories.IBaseRepository;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories
{
    public interface IAdminRepository : ICrudRepository<Admin>, IBaseSearchRepository<Admin>, ISearchByNameRepository<Admin>
    {
    }
}
