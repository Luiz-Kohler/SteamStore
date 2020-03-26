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
    public class AdRepository : IAdRepository
    {
        private SteamStoreContext _context;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public AdRepository(SteamStoreContext context)
        {
            _context = context;
        }

        public async Task<Response> Creat(Ad objectToCreat)
        {
            Response response = new Response();
            try
            {
                _context.Ads.Add(objectToCreat);
                _context.Entry<Ad>(objectToCreat).State = Microsoft.EntityFrameworkCore.EntityState.Added;
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
                DataResponse<Ad> adToDisable = await GetObjectByID(objectToDisableID);

                if (adToDisable.Erros.Count == 0)
                {
                    response.Success = false;
                    response.AddError("Ad.ID", "Não existe um admin com este ID");
                    return response;
                }

                adToDisable.Data[0].ChangeState(false);
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

        public async Task<DataResponse<Ad>> GetAdsForID(Guid SellerID)
        {

            DataResponse<Ad> dataResponse = new DataResponse<Ad>();
            try
            {
                dataResponse.Data =  await _context.Ads.Where(a => a.SellerUserID == SellerID).ToListAsync();
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

        public async Task<DataResponse<Ad>> GetAllObjects()
        {
            DataResponse<Ad> dataResponse = new DataResponse<Ad>();
            try
            {
                dataResponse.Data = await _context.Ads.ToListAsync();
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

        public async Task<DataResponse<Ad>> GetObjectByID(Guid objectToGetID)
        {
            DataResponse<Ad> dataResponse = new DataResponse<Ad>();

            try
            {
                dataResponse.Data.Add(await _context.Ads.FirstOrDefaultAsync(a => a.ID == objectToGetID));
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

        public async Task<Response> Update(Ad objectToUpdate)
        {
            Response response = new Response();
            try
            {
                _context.Entry<Ad>(objectToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
