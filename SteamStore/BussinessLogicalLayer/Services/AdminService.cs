using BussinessLogicalLayer.IServices;
using BussinessLogicalLayer.Validates;
using DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories;
using Entities.Entities;
using Flunt.Notifications;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;
        private AdminValidate _validate;

        public AdminService(IAdminRepository repository)
        {
            _repository = repository;
        }

        public Task<Response> Creat(Admin objectToCreat)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Disable(Guid objectToDisableID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Admin>> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Admin>> GetObjectByID(Guid objectToGetID)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Admin>> GetObjectByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(Admin objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
