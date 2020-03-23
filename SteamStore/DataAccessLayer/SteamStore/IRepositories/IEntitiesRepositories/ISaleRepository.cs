using DataAccessLayer.SteamStore.IRepositories.IBaseRepositories;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories
{
    public interface ISaleRepository : ICrudRepository<Sale>
    {
        Task<List<Sale>> GetSalesByBuyerID(Guid buyerID);
        Task<Sale> GetSalesByAd(Guid adID);
    }
}
