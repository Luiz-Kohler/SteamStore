using BussinessLogicalLayer.IServices;
using Entities.Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class ItemService : IItemService
    {
        public Task<Response> Creat(Item objectToCreat)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Disable(Guid objectToDisableID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Item>> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Item>> GetItemsUserID(Guid userID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Item>> GetObjectByID(Guid objectToGetID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Item>> GetObjectByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(Item objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
