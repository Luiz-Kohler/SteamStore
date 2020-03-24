using BussinessLogicalLayer.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class FriendRequestService : IFriendRequestService
    {
        public Task Creat(FriendRequest objectToCreat)
        {
            throw new NotImplementedException();
        }

        public Task Disable(Guid objectToDisableID)
        {
            throw new NotImplementedException();
        }

        public Task<List<FriendRequest>> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public Task<List<FriendRequest>> GetFriedsRequestByUserID(Guid userID)
        {
            throw new NotImplementedException();
        }

        public Task<FriendRequest> GetObjectByID(Guid objectToGetID)
        {
            throw new NotImplementedException();
        }

        public Task Update(FriendRequest objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
