using DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories;
using Entities.Entities;
using log4net;
using Microsoft.EntityFrameworkCore;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccessLayer.SteamStore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private SteamStoreContext _context;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
            catch (Exception ex)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");

                StringBuilder logMessage = new StringBuilder();
                logMessage.Append(DateTime.Now.ToString());
                log.Error(logMessage.AppendLine(ex.Message).AppendLine(ex.StackTrace).ToString());
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
            catch (Exception ex)
            {
                response.Success = false;
                response.AddError("Banco de dados", "Error no banco de dados, contate um suporte");

                StringBuilder logMessage = new StringBuilder();
                logMessage.Append(DateTime.Now.ToString());
                log.Error(logMessage.AppendLine(ex.Message).AppendLine(ex.StackTrace).ToString());
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
            catch (Exception ex)
            {
                response.Success = false;
                response.AddError("Banco de dados", "Error no banco de dados, contate um suporte");

                StringBuilder logMessage = new StringBuilder(); logMessage.Append(DateTime.Now.ToString());
                logMessage.Append(DateTime.Now.ToString());
                log.Error(logMessage.AppendLine(ex.Message).AppendLine(ex.StackTrace).ToString());
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
            catch (Exception ex)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");

                StringBuilder logMessage = new StringBuilder();
                logMessage.Append(DateTime.Now.ToString());
                log.Error(logMessage.AppendLine(ex.Message).AppendLine(ex.StackTrace).ToString());
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
            catch (Exception ex)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");

                StringBuilder logMessage = new StringBuilder();
                logMessage.Append(DateTime.Now.ToString());
                log.Error(logMessage.AppendLine(ex.Message).AppendLine(ex.StackTrace).ToString());
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
            catch (Exception ex)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");

                StringBuilder logMessage = new StringBuilder();
                logMessage.Append(DateTime.Now.ToString());
                log.Error(logMessage.AppendLine(ex.Message).AppendLine(ex.StackTrace).ToString());
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
            catch (Exception ex)
            {
                response.Success = false;
                response.AddError("Banco de dados", "Error no banco de dados, contate um suporte");

                StringBuilder logMessage = new StringBuilder();
                logMessage.Append(DateTime.Now.ToString());
                log.Error(logMessage.AppendLine(ex.Message).AppendLine(ex.StackTrace).ToString());
            }
            return response;
        }

        public async Task<DataResponse<User>> GetUserByIdForProfile(Guid userID, bool owenr)
        {
            DataResponse<User> dataResponse = new DataResponse<User>();
            try
            {
                dataResponse.Data.Add(owenr ? await _context.Users.Include(u => u.Items).Include(u => u.Ads).Include(u => u.Sales).FirstOrDefaultAsync(u => u.ID == userID)
                                            : await _context.Users.Include(u => u.Items).FirstOrDefaultAsync(u => u.ID == userID));

            }
            catch (Exception ex)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");

                StringBuilder logMessage = new StringBuilder();
                logMessage.Append(DateTime.Now.ToString());
                log.Error(logMessage.AppendLine(ex.Message).AppendLine(ex.StackTrace).ToString());
            }
            return dataResponse;
        }

        public async Task<Response> ChangeCashValues(Guid userReceiveCashID, Guid userGiveCashID, decimal price)
        {
            Response response = new Response();
            try
            {
                using(TransactionScope scope = new TransactionScope())
                {
                    DataResponse<User> users = await GetObjectByID(userReceiveCashID);
                    users.Data.Add(GetObjectByID(userGiveCashID).Result.Data[0]);

                    if (users.Success)
                    {
                        users.Data[0].ChangeCash(price, true);
                        users.Data[1].ChangeCash(price, false);
                    }

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.AddError("Banco de dados", "Error no banco de dados, contate um suporte");

                StringBuilder logMessage = new StringBuilder();
                logMessage.Append(DateTime.Now.ToString());
                log.Error(logMessage.AppendLine(ex.Message).AppendLine(ex.StackTrace).ToString());
            }
            return response;
        }
    }
}
