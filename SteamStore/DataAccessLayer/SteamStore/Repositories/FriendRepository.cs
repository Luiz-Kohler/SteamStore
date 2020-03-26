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

namespace DataAccessLayer.SteamStore.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private SteamStoreContext _context;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public FriendRepository(SteamStoreContext context)
        {
            _context = context;
        }

        public async Task<Response> Creat(Friend objectToCreat)
        {
            Response response = new Response();
            try
            {
                _context.Friends.Add(objectToCreat);
                _context.Entry<Friend>(objectToCreat).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.AddError("Banco de dados", "Error no banco de dados, contate um suporte");

                StringBuilder logMessage = new StringBuilder();
                log.Error(logMessage.AppendLine(ex.Message).AppendLine(ex.StackTrace).ToString());
            }
            return response;
        }

        public async Task<Response> Disable(Guid objectToDisableID)
        {
            Response response = new Response();
            try
            {
                DataResponse<Friend> friendToDisable = await GetObjectByID(objectToDisableID);

                if (friendToDisable.Erros.Count == 0)
                {
                    response.Success = false;
                    response.AddError("Ad.ID", "Não existe um admin com este ID");
                    return response;
                }

                friendToDisable.Data[0].ChangeState(false);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.AddError("Banco de dados", "Error no banco de dados, contate um suporte");

                StringBuilder logMessage = new StringBuilder();
                log.Error(logMessage.AppendLine(ex.Message).AppendLine(ex.StackTrace).ToString());
            }
            return response;
        }

        public async Task<DataResponse<Friend>> GetAllObjects()
        {
            DataResponse<Friend> dataResponse = new DataResponse<Friend>();
            try
            {
                dataResponse.Data =  await _context.Friends.Where(f => f.IsActive).ToListAsync();
            }
            catch (Exception ex)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");

                StringBuilder logMessage = new StringBuilder();
                log.Error(logMessage.AppendLine(ex.Message).AppendLine(ex.StackTrace).ToString());
            }
            return dataResponse;
        }

        public async Task<DataResponse<Friend>> GetFriendsByUserID(Guid userID)
        {
            DataResponse<Friend> dataResponse = new DataResponse<Friend>();
            try
            {
                dataResponse.Data = await _context.Friends.Where(f => f.UserID == userID && f.IsActive).ToListAsync();
            }
            catch (Exception ex)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");

                StringBuilder logMessage = new StringBuilder();
                log.Error(logMessage.AppendLine(ex.Message).AppendLine(ex.StackTrace).ToString());
            }
            return dataResponse;
        }

        public async Task<DataResponse<Friend>> GetObjectByID(Guid objectToGetID)
        {
            DataResponse<Friend> dataResponse = new DataResponse<Friend>();
            try
            {
                dataResponse.Data.Add(await _context.Friends.FirstOrDefaultAsync(f => f.ID == objectToGetID));
            }
            catch (Exception ex)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");

                StringBuilder logMessage = new StringBuilder();
                log.Error(logMessage.AppendLine(ex.Message).AppendLine(ex.StackTrace).ToString());
            }
            return dataResponse;
        }

        public async Task<DataResponse<Friend>> GetObjectByName(string name)
        {
            DataResponse<Friend> dataResponse = new DataResponse<Friend>();
            try
            {
                dataResponse.Data = await _context.Friends.Where(f => f.FriendUser.Nick.Equals(name, StringComparison.OrdinalIgnoreCase) && f.IsActive).ToListAsync();
            }
            catch (Exception ex)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");

                StringBuilder logMessage = new StringBuilder();
                log.Error(logMessage.AppendLine(ex.Message).AppendLine(ex.StackTrace).ToString());
            }
            return dataResponse;
        }

        public async Task<Response> Update(Friend objectToUpdate)
        {
            Response response = new Response();
            try
            {
                _context.Entry<Friend>(objectToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.AddError("Banco de dados", "Error no banco de dados, contate um suporte");

                StringBuilder logMessage = new StringBuilder();
                log.Error(logMessage.AppendLine(ex.Message).AppendLine(ex.StackTrace).ToString());
            }
            return response;
        }
    }
}
