using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SteamStore.IRepositories.IBaseRepository
{
    //Fazer que T só aceite objetos da pasta Entities
    public interface IBaseSearchRepository <T>
    {
        Task<DataResponse<T>> GetAllObjects();
    }
}
