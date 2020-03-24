using BussinessLogicalLayer.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class SaleService : ISaleService
    {
        public Task Creat(Sale objectToCreat)
        {
            throw new NotImplementedException();
        }

        public Task Disable(Guid objectToDisableID)
        {
            throw new NotImplementedException();
        }

        public Task<Sale> GetObjectByID(Guid objectToGetID)
        {
            throw new NotImplementedException();
        }

        public Task<Sale> GetSalesByAd(Guid adID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sale>> GetSalesByBuyerID(Guid buyerID)
        {
            throw new NotImplementedException();
        }

        public Task Update(Sale objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
