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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response> Creat(Comment objectToCreat)
        {
            Response response = Validate.CommentValidate(false, objectToCreat);
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

        public async Task<DataResponse<Comment>> GetAllObjects()
        {
            return await _repository.GetAllObjects();
        }

        public async Task<DataResponse<Comment>> GetCommentsByForUserID(Guid forUserID)
        {
            DataResponse<Comment> response = new DataResponse<Comment>();

            if (forUserID == null)
            {
                response.AddError("ID", "ID invalido");
            }

            return response.HasError() ? response : await _repository.GetCommentsByForUserID(forUserID);
        }

        public async Task<DataResponse<Comment>> GetCommentsByWritterID(Guid writterID)
        {
            DataResponse<Comment> response = new DataResponse<Comment>();

            if (writterID == null)
            {
                response.AddError("ID", "ID invalido");
            }

            return response.HasError() ? response : await _repository.GetCommentsByWritterID(writterID);
        }

        public async Task<DataResponse<Comment>> GetObjectByID(Guid objectToGetID)
        {
            DataResponse<Comment> response = new DataResponse<Comment>();

            if (objectToGetID == null)
            {
                response.AddError("ID", "ID invalido");
            }

            return response.HasError() ? response : await _repository.GetObjectByID(objectToGetID);
        }

        public async Task<Response> Update(Comment objectToUpdate)
        {
            Response response = Validate.CommentValidate(true, objectToUpdate);
            return response.HasError() ? response : await _repository.Update(objectToUpdate);
        }
    }
}
