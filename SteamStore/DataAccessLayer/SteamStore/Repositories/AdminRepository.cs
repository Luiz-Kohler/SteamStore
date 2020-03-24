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
    public class AdminRepository : IAdminRepository
    {
        private SteamStoreContext _context;

        public AdminRepository(SteamStoreContext context)
        {
            _context = context;
        }

        public async Task<Response> Creat(Admin objectToCreat)
        {
            try
            {
                _context.Admins.Add(objectToCreat);
                _context.Entry<Admin>(objectToCreat).State = Microsoft.EntityFrameworkCore.EntityState.Added;
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
                Admin adminToDisable = await GetObjectByID(objectToDisableID);
                adminToDisable.ChangeState(false);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<Admin>> GetAllObjects()
        {
            try
            {
                return await _context.Admins.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<Admin>> GetObjectByID(Guid objectToGetID)
        {
            try
            {
                return await _context.Admins.FirstOrDefaultAsync(a => a.ID == objectToGetID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<Admin>> GetObjectByName(string name)
        {
            try
            {
                return await _context.Admins.Where(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response> Update(Admin objectToUpdate)
        {
            try
            {
                _context.Entry<Admin>(objectToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
