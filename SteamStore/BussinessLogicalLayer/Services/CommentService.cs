using BussinessLogicalLayer.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class CommentService : ICommentService
    {
        public Task Creat(Comment objectToCreat)
        {
            throw new NotImplementedException();
        }

        public Task Disable(Guid objectToDisableID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetCommentsByForUserID(Guid forUserID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetCommentsByWritterID(Guid writterID)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetObjectByID(Guid objectToGetID)
        {
            throw new NotImplementedException();
        }

        public Task Update(Comment objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
