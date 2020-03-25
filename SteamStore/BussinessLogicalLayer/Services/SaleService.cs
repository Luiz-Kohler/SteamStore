using BussinessLogicalLayer.IServices;
using BussinessLogicalLayer.Validates;
using DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories;
using Entities.Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repository;

        public SaleService(ISaleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Creat(Sale objectToCreat)
        {
            Response response = Validate.SaleValidate(false, objectToCreat);
            return response.HasError() ? response : await _repository.Creat(objectToCreat);
        }

        public async Task<Response> Disable(Guid objectToDisableID)
        {
            Response response = new Response();

            if (objectToDisableID == null)
            {
                response.AddError("ID", "ID invalido");
            }

            return response.HasError() ? response : await _repository.Disable(objectToDisableID);
        }

        public async Task<DataResponse<Sale>> GetObjectByID(Guid objectToGetID)
        {
            DataResponse<Sale> response = new DataResponse<Sale>();

            if (objectToGetID == null)
            {
                response.AddError("ID", "ID invalido");
            }

            return response.HasError() ? response : await _repository.GetObjectByID(objectToGetID);
        }

        public async Task<DataResponse<Sale>> GetSaleByAd(Guid adID)
        {
            DataResponse<Sale> response = new DataResponse<Sale>();

            if (adID == null)
            {
                response.AddError("ID", "ID invalido");
            }

            return response.HasError() ? response : await _repository.GetSaleByAd(adID);
        }

        public async Task<DataResponse<Sale>> GetSalesByBuyerID(Guid buyerID)
        {
            DataResponse<Sale> response = new DataResponse<Sale>();

            if (buyerID == null)
            {
                response.AddError("ID", "ID invalido");
            }

            return response.HasError() ? response : await _repository.GetSalesByBuyerID(buyerID);
        }

        public async Task<Response> Update(Sale objectToUpdate)
        {
            Response response = Validate.SaleValidate(true, objectToUpdate);
            return response.HasError() ? response : await _repository.Update(objectToUpdate);
        }
    }
}
