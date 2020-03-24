using BussinessLogicalLayer.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class ItemService : IItemService
    {
        public Task Creat(Item objectToCreat)
        {
            throw new NotImplementedException();
        }

        public Task Disable(Guid objectToDisableID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetItemsUserID(Guid userID)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetObjectByID(Guid objectToGetID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetObjectByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Update(Item objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
