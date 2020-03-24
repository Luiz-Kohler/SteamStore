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
    public class AdRepository : IAdRepository
    {
        private SteamStoreContext _context;

        public AdRepository(SteamStoreContext context)
        {
            _context = context;
        }

        public async Task<Response> Creat(Ad objectToCreat)
        {
            try
            {
                _context.Ads.Add(objectToCreat);
                _context.Entry<Ad>(objectToCreat).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<Response> Disable(Guid objectToDisableID)
        {
            try
            {
                Ad adToDisable = await GetObjectByID(objectToDisableID);
                adToDisable.ChangeState(false);
                _context.Entry<Ad>(adToDisable).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<DataResponse<Ad>> GetAdsForID(Guid SellerID)
        {
            try
            {
                return await _context.Ads.Where(a => a.SellerUserID == SellerID).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<DataResponse<Ad>> GetAllObjects()
        {
            try
            {
                return await _context.Ads.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<Ad>> GetObjectByID(Guid objectToGetID)
        {
            try
            {
                return await _context.Ads.FirstOrDefaultAsync(a => a.ID == objectToGetID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response> Update(Ad objectToUpdate)
        {
            try
            {
                _context.Entry<Ad>(objectToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
