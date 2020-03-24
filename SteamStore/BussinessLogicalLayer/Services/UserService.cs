using BussinessLogicalLayer.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class UserService : IUserService
    {
        public Task Creat(User objectToCreat)
        {
            throw new NotImplementedException();
        }

        public Task Disable(Guid objectToDisableID)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetObjectByID(Guid objectToGetID)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetObjectByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Update(User objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
