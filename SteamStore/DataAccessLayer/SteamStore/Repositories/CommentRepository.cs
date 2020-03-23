using DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SteamStore.Repositories
{
    public class CommentRepository : ICommentRepository
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
