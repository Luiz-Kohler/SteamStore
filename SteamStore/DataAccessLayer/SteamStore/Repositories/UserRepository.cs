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

        public async Task<DataResponse<User>> Authetication(string email, string password)
        {
            DataResponse<User> dataResponse = new DataResponse<User>();
            try
            {
                dataResponse.Data.Add(await _context.Users.FirstOrDefaultAsync(x => x.Login.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && x.Login.Password.Equals(password)));
            }
            catch (Exception)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return dataResponse;
        }

        public async Task<Response> Creat(User objectToCreat)
        {
            Response response = new Response();
            try
            {
                _context.Users.Add(objectToCreat);
                _context.Entry<User>(objectToCreat).State = Microsoft.EntityFrameworkCore.EntityState.Added;
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
                DataResponse<User> userToDisable = await GetObjectByID(objectToDisableID);

                if (userToDisable.Erros.Count == 0)
                {
                    response.Success = false;
                    response.AddError("Ad.ID", "Não existe um admin com este ID");
                    return response;
                }

                userToDisable.Data[0].ChangeState(false);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                response.Success = false;
                response.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return response;
        }

        public async Task<DataResponse<User>> GetAllObjects()
        {
            DataResponse<User> dataResponse = new DataResponse<User>();
            try
            {
                dataResponse.Data =  await _context.Users.Where(u => u.IsActive).ToListAsync();
            }
            catch (Exception)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return dataResponse;
        }

        public async Task<DataResponse<User>> GetObjectByID(Guid objectToGetID)
        {
            DataResponse<User> dataResponse = new DataResponse<User>();

            try
            {
                dataResponse.Data.Add(await _context.Users.FirstAsync(u => u.ID == objectToGetID));
            }
            catch (Exception)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return dataResponse;
        }

        public async Task<DataResponse<User>> GetObjectByName(string name)
        {
            DataResponse<User> dataResponse = new DataResponse<User>();
            try
            {
                dataResponse.Data = await _context.Users.Where(i => i.Nick.Equals(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            }
            catch (Exception)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return dataResponse;
        }

        public async Task<Response> Update(User objectToUpdate)
        {
            Response response = new Response();
            try
            {
                _context.Entry<User>(objectToUpdate).State = EntityState.Modified;
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
