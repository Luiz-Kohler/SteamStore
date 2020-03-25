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

        public async Task<DataResponse<Admin>> Authetication(string email, string password)
        {
            DataResponse<Admin> dataResponse = new DataResponse<Admin>();
            try
            {
                dataResponse.Data.Add(await _context.Admins.FirstOrDefaultAsync(x => x.Login.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && x.Login.Password.Equals(password)));
            }
            catch (Exception)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return dataResponse;
        }

        public async Task<Response> Creat(Admin objectToCreat)
        {
            Response response = new Response();
            try
            {
                _context.Admins.Add(objectToCreat);
                _context.Entry<Admin>(objectToCreat).State = Microsoft.EntityFrameworkCore.EntityState.Added;
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
                DataResponse<Admin> adminToDisable = await GetObjectByID(objectToDisableID);

                if(adminToDisable.Erros.Count == 0)
                {
                    response.Success = false;
                    response.AddError("Admin.ID", "Não existe um admin com este ID");
                    return response;
                }

                adminToDisable.Data[0].ChangeState(false);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                response.Success = false;
                response.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return response;

        }

        public async Task<DataResponse<Admin>> GetAllObjects()
        {
            DataResponse<Admin> dataResponse = new DataResponse<Admin>();

            try
            {
                dataResponse.Data = await _context.Admins.ToListAsync();
            }
            catch (Exception)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return dataResponse;

        }

        public async Task<DataResponse<Admin>> GetObjectByID(Guid objectToGetID)
        {
            DataResponse<Admin> dataResponse = new DataResponse<Admin>();

            try
            {
                dataResponse.Data.Add(await _context.Admins.FirstOrDefaultAsync(a => a.ID == objectToGetID));
            }
            catch (Exception)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return dataResponse;

        }

        public async Task<DataResponse<Admin>> GetObjectByName(string name)
        {
            DataResponse<Admin> dataResponse = new DataResponse<Admin>();

            try
            {
                dataResponse.Data = await _context.Admins.Where(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            }
            catch (Exception)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return dataResponse;

        }

        public async Task<Response> Update(Admin objectToUpdate)
        {
            Response response = new Response();

            try
            {
                _context.Entry<Admin>(objectToUpdate).State = EntityState.Modified;
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
