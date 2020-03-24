using BussinessLogicalLayer.IServices;
using Entities.Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class AdService : IAdService
    {
        public Task<Response> Creat(Ad objectToCreat)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Disable(Guid objectToDisableID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Ad>> GetAdsForID(Guid SellerID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Ad>> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Ad>> GetObjectByID(Guid objectToGetID)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(Ad objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
