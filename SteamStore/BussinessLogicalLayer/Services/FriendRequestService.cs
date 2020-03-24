using BussinessLogicalLayer.IServices;
using Entities.Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class FriendRequestService : IFriendRequestService
    {
        public Task<Response> Creat(FriendRequest objectToCreat)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Disable(Guid objectToDisableID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<FriendRequest>> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<FriendRequest>> GetFriedsRequestByUserID(Guid userID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<FriendRequest>> GetObjectByID(Guid objectToGetID)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(FriendRequest objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
