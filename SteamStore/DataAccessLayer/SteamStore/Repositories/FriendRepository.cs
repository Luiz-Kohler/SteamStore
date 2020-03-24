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
    public class FriendRepository : IFriendRepository
    {
        private SteamStoreContext _context;

        public FriendRepository(SteamStoreContext context)
        {
            _context = context;
        }

        public async Task<Response> Creat(Friend objectToCreat)
        {
            try
            {
                _context.Friends.Add(objectToCreat);
                _context.Entry<Friend>(objectToCreat).State = Microsoft.EntityFrameworkCore.EntityState.Added;
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
                Friend friendToDisable = await GetObjectByID(objectToDisableID);
                friendToDisable.ChangeState(false);
                _context.Entry<Friend>(friendToDisable).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<Friend>> GetAllObjects()
        {
            try
            {
                return await _context.Friends.Where(f => f.IsActive).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<Friend>> GetFriedsByUserID(Guid userID)
        {
            try
            {
                return await _context.Friends.Where(f => f.UserID == userID && f.IsActive).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<Friend>> GetObjectByID(Guid objectToGetID)
        {
            try
            {
                return await _context.Friends.FirstOrDefaultAsync(f => f.ID == objectToGetID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<Friend>> GetObjectByName(string name)
        {
            try
            {
                return await _context.Friends.Where(f => f.FriendUser.Nick.Equals(name, StringComparison.OrdinalIgnoreCase) && f.IsActive).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response> Update(Friend objectToUpdate)
        {
            try
            {
                _context.Entry<Friend>(objectToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
