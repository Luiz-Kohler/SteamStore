using BussinessLogicalLayer.IServices;
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
        public Task<Response> Creat(Comment objectToCreat)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Disable(Guid objectToDisableID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Comment>> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Comment>> GetCommentsByForUserID(Guid forUserID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Comment>> GetCommentsByWritterID(Guid writterID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Comment>> GetObjectByID(Guid objectToGetID)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(Comment objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
