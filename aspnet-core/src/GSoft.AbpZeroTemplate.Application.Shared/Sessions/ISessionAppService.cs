using System.Threading.Tasks;
using Abp.Application.Services;
using GSoft.AbpZeroTemplate.Sessions.Dto;

namespace GSoft.AbpZeroTemplate.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
