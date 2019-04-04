using System.Threading.Tasks;
using Abp.Application.Services;
using GSoft.AbpZeroTemplate.Install.Dto;

namespace GSoft.AbpZeroTemplate.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}