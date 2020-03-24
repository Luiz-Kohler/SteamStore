using BussinessLogicalLayer.IServices;
using Entities.Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class UserService : IUserService
    {
        public Task<Response> Creat(User objectToCreat)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Disable(Guid objectToDisableID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<User>> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<User>> GetObjectByID(Guid objectToGetID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<User>> GetObjectByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(User objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
