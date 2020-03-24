using BussinessLogicalLayer.IServices;
using BussinessLogicalLayer.Validates;
using DataAccessLayer.SteamStore.IRepositories.IEntitiesRepositories;
using Entities.Entities;
using Flunt.Notifications;
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

        public Task Creat(Admin objectToCreat)
        {
            IReadOnlyCollection<Notification> totalNotifications= _validate.ValidateObjectToCreat(objectToCreat);
            if(totalNotifications.Count > 0)
            {

            }
              
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
