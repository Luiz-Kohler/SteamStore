using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SteamStore.IRepositories.IBaseRepository
{
    public interface SearchByName <T>
    {
        Task<List<T>> GetObjectByName(string name);
    }
}
