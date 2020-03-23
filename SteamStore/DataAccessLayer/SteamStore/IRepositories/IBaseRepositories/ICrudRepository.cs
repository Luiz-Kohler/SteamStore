using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SteamStore.IRepositories.IBaseRepositories
{
    //Fazer que T só aceite objetos da pasta Entities
    public interface ICrudRepository <T>
    {
        Task Creat(T objectToCreat);
        Task Disable(Guid objectToDisableID);
        Task Update(T objectToUpdate);
        Task<T> GetObjectByID(Guid objectToGetID);
    }
}
