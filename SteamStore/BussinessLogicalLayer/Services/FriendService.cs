using BussinessLogicalLayer.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class FriendService : IFriendService
    {
        public Task Creat(Friend objectToCreat)
        {
            throw new NotImplementedException();
        }

        public Task Disable(Guid objectToDisableID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Friend>> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public Task<List<Friend>> GetFriedsByUserID(Guid userID)
        {
            throw new NotImplementedException();
        }

        public Task<Friend> GetObjectByID(Guid objectToGetID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Friend>> GetObjectByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Update(Friend objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
