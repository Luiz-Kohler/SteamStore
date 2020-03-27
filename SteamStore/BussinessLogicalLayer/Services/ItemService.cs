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
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> ChangeOwner(Guid newUserOwnerID, Guid itemID)
        {
            return await _repository.ChangeOwner(newUserOwnerID, itemID);
        }

        public async Task<Response> Creat(Item objectToCreat)
        {
            Response response = Validate.ItemValidate(false, objectToCreat);
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

        public async Task<DataResponse<Item>> GetAllObjects()
        {
            return await _repository.GetAllObjects();
        }

        public async Task<DataResponse<Item>> GetItemsUserID(Guid userID)
        {
            DataResponse<Item> response = new DataResponse<Item>();

            if (userID == null)
            {
                response.AddError("ID", "ID invalido");
            }

            return response.HasError() ? response : await _repository.GetItemsUserID(userID);
        }

        public async Task<DataResponse<Item>> GetObjectByID(Guid objectToGetID)
        {
            DataResponse<Item> response = new DataResponse<Item>();

            if (objectToGetID == null)
            {
                response.AddError("ID", "ID invalido");
            }

            return response.HasError() ? response : await _repository.GetObjectByID(objectToGetID);
        }

        public async Task<DataResponse<Item>> GetObjectByName(string name)
        {
            DataResponse<Item> response = new DataResponse<Item>();

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

        public async Task<Response> Update(Item objectToUpdate)
        {
            Response response = Validate.ItemValidate(true, objectToUpdate);
            return response.HasError() ? response : await _repository.Update(objectToUpdate);
        }
    }
}
