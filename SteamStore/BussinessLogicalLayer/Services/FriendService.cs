using BussinessLogicalLayer.IServices;
using BussinessLogicalLayer.Validates;
using DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories;
using Entities.Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository _repository;

        public FriendService(IFriendRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Creat(Friend objectToCreat)
        {
            Response response = Validate.FriendValidate(false, objectToCreat);
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

        public async Task<DataResponse<Friend>> GetAllObjects()
        {
            return await _repository.GetAllObjects();
        }

        public async Task<DataResponse<Friend>> GetFriendsByUserID(Guid userID)
        {
            DataResponse<Friend> response = new DataResponse<Friend>();

            if (userID == null)
            {
                response.AddError("ID", "ID invalido");
            }

            return response.HasError() ? response : await _repository.GetFriendsByUserID(userID);
        }

        public async Task<DataResponse<Friend>> GetObjectByID(Guid objectToGetID)
        {
            DataResponse<Friend> response = new DataResponse<Friend>();

            if (objectToGetID == null)
            {
                response.AddError("ID", "ID invalido");
            }

            return response.HasError() ? response : await _repository.GetObjectByID(objectToGetID);
        }

        public async Task<DataResponse<Friend>> GetObjectByName(string name)
        {
            DataResponse<Friend> response = new DataResponse<Friend>();

            if (string.IsNullOrWhiteSpace(name))
            {
                response.AddError("Name", "O nome deve ser informado");
            }
            else
            {
                name = name.ToLower().Trim();
                name = Regex.Replace(name, @"\s+", " ");

                if(name.Length < 2 && name.Length > 20)
                {
                    response.AddError("Name", "O nome deve conter entre 2 a 20 caracteres");
                }
            }

            return response.HasError() ? response : await _repository.GetObjectByName(name);
        }

        public async Task<Response> Update(Friend objectToUpdate)
        {
            Response response = Validate.FriendValidate(true, objectToUpdate);
            return response.HasError() ? response : await _repository.Update(objectToUpdate);
        }
    }
}
