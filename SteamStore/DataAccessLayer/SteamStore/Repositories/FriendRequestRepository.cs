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
    public class FriendRequestRepository : IFriendRequestRepository
    {
        private SteamStoreContext _context;

        public FriendRequestRepository(SteamStoreContext context)
        {
            _context = context;
        }

        public async Task Creat(FriendRequest objectToCreat)
        {
            try
            {
                _context.FriendRequests.Add(objectToCreat);
                _context.Entry<FriendRequest>(objectToCreat).State = Microsoft.EntityFrameworkCore.EntityState.Added;
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
                FriendRequest friendRequestToDisable = await GetObjectByID(objectToDisableID);
                friendRequestToDisable.ChangeState(false);

                _context.Entry<FriendRequest>(friendRequestToDisable).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<FriendRequest>> GetAllObjects()
        {
            try
            {
                return await _context.FriendRequests.Where(f => f.IsActive).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<FriendRequest>> GetFriedsRequestByUserID(Guid userID)
        {
            try
            {
                return await _context.FriendRequests.Where(f =>  f.ForUserID == userID && f.IsActive).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<FriendRequest> GetObjectByID(Guid objectToGetID)
        {
            try
            {
                return await _context.FriendRequests.FirstOrDefaultAsync(f => f.ID == objectToGetID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Update(FriendRequest objectToUpdate)
        {
            try
            {
                _context.Entry<FriendRequest>(objectToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
