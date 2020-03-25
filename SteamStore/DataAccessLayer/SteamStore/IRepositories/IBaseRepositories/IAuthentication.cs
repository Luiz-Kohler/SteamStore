using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SteamStore.IRepositories.IBaseRepositories
{
    public interface IAuthentication <T>
    {
        Task<DataResponse<T>> Authetication(string email, string password);
    }
}
