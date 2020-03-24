using DataAccessLayer.SteamStore.IRepositories.IBaseRepositories;
using Entities.Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories
{
    public interface ISaleRepository : ICrudRepository<Sale>
    {
        Task<DataResponse<Sale>> GetSalesByBuyerID(Guid buyerID);
        Task<DataResponse<Sale>> GetSaleByAd(Guid adID);
    }
}
