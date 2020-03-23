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
    public class SaleRepository : ISaleRepository
    {
        private SteamStoreContext _context;

        public SaleRepository(SteamStoreContext context)
        {
            _context = context;
        }

        public async Task Creat(Sale objectToCreat)
        {
            try
            {
                _context.Sales.Add(objectToCreat);
                _context.Entry<Sale>(objectToCreat).State = Microsoft.EntityFrameworkCore.EntityState.Added;
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
                Sale saleToDisable = await GetObjectByID(objectToDisableID);
                saleToDisable.ChangeState(false);

                _context.Entry<Sale>(saleToDisable).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Sale> GetObjectByID(Guid objectToGetID)
        {
            try
            {
                return await _context.Sales.FirstOrDefaultAsync(i => i.ID == objectToGetID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Sale> GetSalesByAd(Guid adID)
        {
            try
            {
                return await _context.Sales.FirstOrDefaultAsync(i => i.AdId == adID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Sale>> GetSalesByBuyerID(Guid buyerID)
        {
            try
            {
                return await _context.Sales.Where(i => i.BuyerId == buyerID).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Update(Sale objectToUpdate)
        {
            try
            {
                _context.Entry<Sale>(objectToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
