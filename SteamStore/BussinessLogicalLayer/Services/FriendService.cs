using BussinessLogicalLayer.IServices;
using Entities.Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class FriendService : IFriendService
    {
        public Task<Response> Creat(Friend objectToCreat)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Disable(Guid objectToDisableID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Friend>> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Friend>> GetFriedsByUserID(Guid userID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Friend>> GetObjectByID(Guid objectToGetID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Friend>> GetObjectByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(Friend objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
