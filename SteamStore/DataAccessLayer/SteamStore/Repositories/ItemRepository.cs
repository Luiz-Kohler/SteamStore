using DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SteamStore.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private SteamStoreContext _context;

        public ItemRepository(SteamStoreContext context)
        {
            _context = context;
        }

        public async Task<Response> Creat(Item objectToCreat)
        {
            try
            {
                _context.Items.Add(objectToCreat);
                _context.Entry<Item>(objectToCreat).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response> Disable(Guid objectToDisableID)
        {
            try
            {
                Item itemToDisable = await GetObjectByID(objectToDisableID);
                itemToDisable.ChangeState(false);

                _context.Entry<Item>(itemToDisable).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<Item>> GetAllObjects()
        {
            try
            {
                return await _context.Items.Where(i => i.IsActive).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<Item>> GetItemsUserID(Guid userID)
        {
            try
            {
                return await _context.Items.Where(i => i.UserID == userID && i.IsActive).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<Item>> GetObjectByID(Guid objectToGetID)
        {
            try
            {
                return await _context.Items.FirstOrDefaultAsync(i => i.ID == objectToGetID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<Item>> GetObjectByName(string name)
        {
            try
            {
                return await _context.Items.Where(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response> Update(Item objectToUpdate)
        {
            try
            {
                _context.Entry<Item>(objectToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
