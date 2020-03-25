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
    public class AdService : IAdService
    {

        private readonly IAdRepository _repository;

        public AdService(IAdRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Creat(Ad objectToCreat)
        {
            Response response = Validate.AdValidate(false, objectToCreat);
            return response.HasError() ? response : await _repository.Creat(objectToCreat); 
        }

        public async Task<Response> Disable(Guid objectToDisableID)
        {
            Response response = new Response();

            if(objectToDisableID == null)
            {
                response.AddError("ID", "ID invalido");
            }

            return response.HasError() ? response : await _repository.Disable(objectToDisableID);
        }

        public async Task<DataResponse<Ad>> GetAdsForID(Guid SellerID)
        {
            DataResponse<Ad> response = new DataResponse<Ad>();

            if (SellerID == null)
            {
                response.AddError("ID", "ID invalido");
            }

            return response.HasError() ? response : await _repository.GetAdsForID(SellerID);
        }

        public async Task<DataResponse<Ad>> GetAllObjects()
        {
            return await _repository.GetAllObjects();
        }

        public async Task<DataResponse<Ad>> GetObjectByID(Guid objectToGetID)
        {
            DataResponse<Ad> response = new DataResponse<Ad>();

            if (objectToGetID == null)
            {
                response.AddError("ID", "ID invalido");
            }

            return response.HasError() ? response : await _repository.GetObjectByID(objectToGetID);
        }

        public async Task<Response> Update(Ad objectToUpdate)
        {
            Response response = Validate.AdValidate(true, objectToUpdate);
            return response.HasError() ? response : await _repository.Update(objectToUpdate);
        }
    }
}
