using BussinessLogicalLayer.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class AdService : IAdService
    {
        public Task Creat(Ad objectToCreat)
        {
            throw new NotImplementedException();
        }

        public Task Disable(Guid objectToDisableID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ad>> GetAdsForID(Guid SellerID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ad>> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public Task<Ad> GetObjectByID(Guid objectToGetID)
        {
            throw new NotImplementedException();
        }

        public Task Update(Ad objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
