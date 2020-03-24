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
            Response response = new Response();
            try
            {
                _context.Items.Add(objectToCreat);
                _context.Entry<Item>(objectToCreat).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                response.Success = false;
                response.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return response;
        }

        public async Task<Response> Disable(Guid objectToDisableID)
        {
            Response response = new Response();
            try
            {
                DataResponse<Item> itemToDisable = await GetObjectByID(objectToDisableID);

                if (itemToDisable.Erros.Count == 0)
                {
                    response.Success = false;
                    response.AddError("Ad.ID", "Não existe um admin com este ID");
                    return response;
                }

                itemToDisable.Data[0].ChangeState(false);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                response.Success = false;
                response.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return response;
        }

        public async Task<DataResponse<Item>> GetAllObjects()
        {
            DataResponse<Item> dataResponse = new DataResponse<Item>();
            try
            {
                dataResponse.Data =  await _context.Items.Where(i => i.IsActive).ToListAsync();
            }
            catch (Exception)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return dataResponse;
        }

        public async Task<DataResponse<Item>> GetItemsUserID(Guid userID)
        {
            DataResponse<Item> dataResponse = new DataResponse<Item>();

            try
            {
                dataResponse.Data = await _context.Items.Where(i => i.UserID == userID && i.IsActive).ToListAsync();
            }
            catch (Exception)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return dataResponse;
        }

        public async Task<DataResponse<Item>> GetObjectByID(Guid objectToGetID)
        {
            DataResponse<Item> dataResponse = new DataResponse<Item>();

            try
            {
                dataResponse.Data.Add(await _context.Items.FirstOrDefaultAsync(i => i.ID == objectToGetID));
            }
            catch (Exception)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return dataResponse;
        }

        public async Task<DataResponse<Item>> GetObjectByName(string name)
        {
            DataResponse<Item> dataResponse = new DataResponse<Item>();

            try
            {
                dataResponse.Data = await _context.Items.Where(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            }
            catch (Exception)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return dataResponse;
        }

        public async Task<Response> Update(Item objectToUpdate)
        {
            Response response = new Response();
            try
            {
                _context.Entry<Item>(objectToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                response.Success = false;
                response.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return response;
        }
    }
}
