using System.Threading.Tasks;
using MyCompanyName.AbpZeroTemplate.ApiClient.Models;

namespace MyCompanyName.AbpZeroTemplate.ApiClient
{
    public interface IAccessTokenManager
    {
        Task<string> GetAccessTokenAsync();
         
        Task<AbpAuthenticateResultModel> LoginAsync();

        void Logout();

        bool IsUserLoggedIn { get; }
    }
}