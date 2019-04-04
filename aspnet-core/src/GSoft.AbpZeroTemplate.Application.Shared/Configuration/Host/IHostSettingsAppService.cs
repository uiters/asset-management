using System.Threading.Tasks;
using Abp.Application.Services;
using GSoft.AbpZeroTemplate.Configuration.Host.Dto;

namespace GSoft.AbpZeroTemplate.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
