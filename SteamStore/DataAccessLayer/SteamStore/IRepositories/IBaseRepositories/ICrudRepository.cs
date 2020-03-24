using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SteamStore.IRepositories.IBaseRepositories
{
    //Fazer que T só aceite objetos da pasta Entities
    public interface ICrudRepository <T>
    {
        Task<Response> Creat(T objectToCreat);
        Task<Response> Disable(Guid objectToDisableID);
        Task<Response> Update(T objectToUpdate);
        Task<DataResponse<T>> GetObjectByID(Guid objectToGetID);
    }
}
