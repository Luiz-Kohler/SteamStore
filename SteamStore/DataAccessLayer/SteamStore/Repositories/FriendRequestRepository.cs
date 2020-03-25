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
    public class FriendRequestRepository : IFriendRequestRepository
    {
        private SteamStoreContext _context;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public FriendRequestRepository(SteamStoreContext context)
        {
            _context = context;
        }

        public async Task<Response> Creat(FriendRequest objectToCreat)
        {
            Response response = new Response();
            try
            {
                _context.FriendRequests.Add(objectToCreat);
                _context.Entry<FriendRequest>(objectToCreat).State = Microsoft.EntityFrameworkCore.EntityState.Added;
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
                DataResponse<FriendRequest> friendRequestToDisable = await GetObjectByID(objectToDisableID);

                if (friendRequestToDisable.Erros.Count == 0)
                {
                    response.Success = false;
                    response.AddError("Ad.ID", "Não existe um admin com este ID");
                    return response;
                }

                friendRequestToDisable.Data[0].ChangeState(false);
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

        public async Task<DataResponse<FriendRequest>> GetAllObjects()
        {
            DataResponse<FriendRequest> dataResponse = new DataResponse<FriendRequest>();
            try
            {
                dataResponse.Data = await _context.FriendRequests.Where(f => f.IsActive).ToListAsync();
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

        public async Task<DataResponse<FriendRequest>> GetFriedsRequestByUserID(Guid userID)
        {
            DataResponse<FriendRequest> dataResponse = new DataResponse<FriendRequest>();
            try
            {
                dataResponse.Data = await _context.FriendRequests.Where(f =>  f.ForUserID == userID && f.IsActive).ToListAsync();
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

        public async Task<DataResponse<FriendRequest>> GetObjectByID(Guid objectToGetID)
        {
            DataResponse<FriendRequest> dataResponse = new DataResponse<FriendRequest>();
            try
            {
                dataResponse.Data.Add(await _context.FriendRequests.FirstOrDefaultAsync(f => f.ID == objectToGetID));
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

        public async Task<Response> Update(FriendRequest objectToUpdate)
        {
            Response response = new Response();
            try
            {
                _context.Entry<FriendRequest>(objectToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
