using Abp.Application.Services;
using GSoft.AbpZeroTemplate.Dto;
using GSoft.AbpZeroTemplate.Logging.Dto;

namespace GSoft.AbpZeroTemplate.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
