using DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task Creat(Item objectToCreat)
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

        public async Task Disable(Guid objectToDisableID)
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

        public async Task<List<Item>> GetAllObjects()
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

        public async Task<List<Item>> GetItemsUserID(Guid userID)
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

        public async Task<Item> GetObjectByID(Guid objectToGetID)
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

        public async Task<List<Item>> GetObjectByName(string name)
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

        public async Task Update(Item objectToUpdate)
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
