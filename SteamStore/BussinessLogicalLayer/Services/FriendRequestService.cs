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
    public class FriendRequestService : IFriendRequestService
    {
        private readonly IFriendRequestRepository _repository;

        public FriendRequestService(IFriendRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Creat(FriendRequest objectToCreat)
        {
            Response response = Validate.FriendRequestValidate(false, objectToCreat);
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

        public async Task<DataResponse<FriendRequest>> GetAllObjects()
        {
            return await _repository.GetAllObjects();
        }

        public async Task<DataResponse<FriendRequest>> GetFriedsRequestByUserID(Guid userID)
        {
            DataResponse<FriendRequest> response = new DataResponse<FriendRequest>();

            if (userID == null)
            {
                response.AddError("ID", "ID invalido");
            }

            return response.HasError() ? response : await _repository.GetFriedsRequestByUserID(userID);
        }

        public async Task<DataResponse<FriendRequest>> GetObjectByID(Guid objectToGetID)
        {
            DataResponse<FriendRequest> response = new DataResponse<FriendRequest>();

            if (objectToGetID == null)
            {
                response.AddError("ID", "ID invalido");
            }

            return response.HasError() ? response : await _repository.GetObjectByID(objectToGetID);
        }

        public async Task<Response> Update(FriendRequest objectToUpdate)
        {
            Response response = Validate.FriendRequestValidate(true, objectToUpdate);
            return response.HasError() ? response : await _repository.Update(objectToUpdate);
        }
    }
}
