using System.Threading.Tasks;
using Abp.Application.Services;
using GSoft.AbpZeroTemplate.Configuration.Tenants.Dto;

namespace GSoft.AbpZeroTemplate.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
