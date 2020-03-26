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
    public class SaleRepository : ISaleRepository
    {
        private SteamStoreContext _context;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public SaleRepository(SteamStoreContext context)
        {
            _context = context;
        }

        public async Task<Response> Creat(Sale objectToCreat)
        {
            Response response = new Response();
            try
            {
                _context.Sales.Add(objectToCreat);
                _context.Entry<Sale>(objectToCreat).State = Microsoft.EntityFrameworkCore.EntityState.Added;
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
                DataResponse<Sale> saleToDisable = await GetObjectByID(objectToDisableID);

                if (saleToDisable.Erros.Count == 0)
                {
                    response.Success = false;
                    response.AddError("Ad.ID", "Não existe um admin com este ID");
                    return response;
                }

                saleToDisable.Data[0].ChangeState(false);
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

        public async Task<DataResponse<Sale>> GetObjectByID(Guid objectToGetID)
        {
            DataResponse<Sale> dataResponse = new DataResponse<Sale>();
            try
            {
                dataResponse.Data.Add(await _context.Sales.FirstOrDefaultAsync(i => i.ID == objectToGetID));
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

        public async Task<DataResponse<Sale>> GetSaleByAd(Guid adID)
        {
            DataResponse<Sale> dataResponse = new DataResponse<Sale>();

            try
            {
                dataResponse.Data.Add(await _context.Sales.FirstOrDefaultAsync(i => i.AdId == adID));
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

        public async Task<DataResponse<Sale>> GetSalesByBuyerID(Guid buyerID)
        {
            DataResponse<Sale> dataResponse = new DataResponse<Sale>();

            try
            {
                dataResponse.Data = await _context.Sales.Where(i => i.BuyerId == buyerID).ToListAsync();
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

        public async Task<Response> Update(Sale objectToUpdate)
        {
            Response response = new Response();
            try
            {
                _context.Entry<Sale>(objectToUpdate).State = EntityState.Modified;
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
    }
}
