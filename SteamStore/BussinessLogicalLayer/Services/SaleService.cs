using BussinessLogicalLayer.IServices;
using Entities.Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class SaleService : ISaleService
    {
        public Task<Response> Creat(Sale objectToCreat)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Disable(Guid objectToDisableID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Sale>> GetObjectByID(Guid objectToGetID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Sale>> GetSaleByAd(Guid adID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Sale>> GetSalesByBuyerID(Guid buyerID)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(Sale objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
