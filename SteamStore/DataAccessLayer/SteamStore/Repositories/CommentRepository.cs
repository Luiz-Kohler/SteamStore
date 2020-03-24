﻿using DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories;
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
            Response response = new Response();
            try
            {
                _context.Comments.Add(objectToCreat);
                _context.Entry<Comment>(objectToCreat).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                response.Success = false;
                response.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return response;
        }

        public async Task<Response> Disable(Guid objectToDisableID)
        {
            Response response = new Response();
            try
            {
                DataResponse<Comment> commentToDisable = await GetObjectByID(objectToDisableID);

                if (commentToDisable.Erros.Count == 0)
                {
                    response.Success = false;
                    response.AddError("Ad.ID", "Não existe um admin com este ID");
                    return response;
                }

                commentToDisable.Data[0].ChangeState(false);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                response.Success = false;
                response.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return response;
        }

        public async Task<DataResponse<Comment>> GetAllObjects()
        {
            DataResponse<Comment> dataResponse = new DataResponse<Comment>();
            try
            {
                dataResponse.Data = await _context.Comments.Where(c => c.IsActive).ToListAsync();
            }
            catch (Exception)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return dataResponse;
        }

        public async Task<DataResponse<Comment>> GetCommentsByForUserID(Guid forUserID)
        {
            DataResponse<Comment> dataResponse = new DataResponse<Comment>();

            try
            {
                dataResponse.Data = await _context.Comments.Where(c => c.ForUserID == forUserID && c.IsActive).ToListAsync();
            }
            catch (Exception)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return dataResponse;
        }

        public async Task<DataResponse<Comment>> GetCommentsByWritterID(Guid writterID)
        {
            DataResponse<Comment> dataResponse = new DataResponse<Comment>();
            try
            {
                dataResponse.Data = await _context.Comments.Where(c => c.WritterID == writterID && c.IsActive).ToListAsync();
            }
            catch (Exception)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return dataResponse;
        }

        public async Task<DataResponse<Comment>> GetObjectByID(Guid objectToGetID)
        {
            DataResponse<Comment> dataResponse = new DataResponse<Comment>();

            try
            {
                dataResponse.Data.Add(await _context.Comments.FirstOrDefaultAsync(c => c.ID == objectToGetID));
            }
            catch (Exception)
            {
                dataResponse.Success = false;
                dataResponse.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return dataResponse;
        }

        public async Task<Response> Update(Comment objectToUpdate)
        {
            Response response = new Response();
            try
            {
                _context.Entry<Comment>(objectToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                response.Success = false;
                response.AddError("Banco de dados", "Error no banco de dados, contate um suporte");
            }
            return response;
        }
    }
}
