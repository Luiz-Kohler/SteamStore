using DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SteamStore.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private SteamStoreContext _context;

        public CommentRepository(SteamStoreContext context)
        {
            _context = context;
        }

        public async Task<Response> Creat(Comment objectToCreat)
        {
            try
            {
                _context.Comments.Add(objectToCreat);
                _context.Entry<Comment>(objectToCreat).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response> Disable(Guid objectToDisableID)
        {
            try
            {
                Comment commentToDisable = await GetObjectByID(objectToDisableID);
                commentToDisable.ChangeState(false);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<Comment>> GetAllObjects()
        {
            try
            {
                return await _context.Comments.Where(c => c.IsActive).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<Comment>> GetCommentsByForUserID(Guid forUserID)
        {
            try
            {
                return await _context.Comments.Where(c => c.ForUserID == forUserID && c.IsActive).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<Comment>> GetCommentsByWritterID(Guid writterID)
        {
            try
            {
                return await _context.Comments.Where(c => c.WritterID == writterID && c.IsActive).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataResponse<Comment>> GetObjectByID(Guid objectToGetID)
        {
            try
            {
                return await _context.Comments.FirstOrDefaultAsync(c => c.ID == objectToGetID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response> Update(Comment objectToUpdate)
        {
            try
            {
                _context.Entry<Comment>(objectToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
