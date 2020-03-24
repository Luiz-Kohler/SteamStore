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
    public class UserRepository : IUserRepository
    {
        private SteamStoreContext _context;

        public UserRepository(SteamStoreContext context)
        {
            _context = context;
        }

        public async Task<Response> Creat(User objectToCreat)
        {
            try
            {
                _context.Users.Add(objectToCreat);
                _context.Entry<User>(objectToCreat).State = Microsoft.EntityFrameworkCore.EntityState.Added;
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
                User userToDisable = await GetObjectByID(objectToDisableID);
                userToDisable.ChangeState(false);

                _context.Entry<User>(userToDisable).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<User>> GetAllObjects()
        {
            try
            {
                return await _context.Users.Where(u => u.IsActive).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<User>> GetObjectByID(Guid objectToGetID)
        {
            try
            {
                return await _context.Users.FirstAsync(u => u.ID == objectToGetID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<User>> GetObjectByName(string name)
        {
            try
            {
                return await _context.Users.Where(i => i.Nick.Equals(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response> Update(User objectToUpdate)
        {
            try
            {
                _context.Entry<User>(objectToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
