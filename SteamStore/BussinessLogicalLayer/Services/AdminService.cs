using BussinessLogicalLayer.IServices;
using DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicalLayer.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;

        public AdminService(IAdminRepository repository)
        {
            _repository = repository;
        }

        public Task Creat(Admin objectToCreat)
        {
            throw new NotImplementedException();
        }

        public Task Disable(Guid objectToDisableID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Admin>> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public Task<Admin> GetObjectByID(Guid objectToGetID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Admin>> GetObjectByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Update(Admin objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
