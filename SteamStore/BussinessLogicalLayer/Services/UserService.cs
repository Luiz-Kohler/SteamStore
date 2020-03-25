using BussinessLogicalLayer.IServices;
using BussinessLogicalLayer.Validates;
using DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories;
using Entities.ComplexTypes;
using Entities.Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<DataResponse<User>> Authetication(string email, string password)
        {
            DataResponse<User> dataResponse = (DataResponse<User>)Validate.ValidateLoginUser(email, password);

            return dataResponse.HasError() ? dataResponse : await _repository.Authetication(email, password);
        }

        public async Task<Response> Creat(User objectToCreat)
        {
            Response response = Validate.UserValidate(false, objectToCreat);
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

        public async Task<DataResponse<User>> GetAllObjects()
        {
            return await _repository.GetAllObjects();
        }

        public async Task<DataResponse<User>> GetObjectByID(Guid objectToGetID)
        {
            DataResponse<User> response = new DataResponse<User>();

            if (objectToGetID == null)
            {
                response.AddError("ID", "ID invalido");
            }

            return response.HasError() ? response : await _repository.GetObjectByID(objectToGetID);
        }

        public async Task<DataResponse<User>> GetObjectByName(string name)
        {
            DataResponse<User> response = new DataResponse<User>();

            if (string.IsNullOrWhiteSpace(name))
            {
                response.AddError("Name", "O nome deve ser informado");
            }
            else
            {
                name = name.ToLower().Trim();
                name = Regex.Replace(name, @"\s+", " ");

                if (name.Length < 2 && name.Length > 20)
                {
                    response.AddError("Name", "O nome deve conter entre 2 a 20 caracteres");
                }
            }

            return response.HasError() ? response : await _repository.GetObjectByName(name);
        }

        public async Task<Response> Update(User objectToUpdate)
        {
            Response response = Validate.UserValidate(true, objectToUpdate);
            return response.HasError() ? response : await _repository.Update(objectToUpdate);
        }
    }
}
