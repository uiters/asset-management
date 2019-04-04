using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GSoft.AbpZeroTemplate.Common.Dto;
using GSoft.AbpZeroTemplate.Editions.Dto;

namespace GSoft.AbpZeroTemplate.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultDto<SubscribableEditionComboboxItemDto>> GetEditionsForCombobox(bool onlyFreeItems = false);

        Task<PagedResultDto<NameValueDto>> FindUsers(FindUsersInput input);

        GetDefaultEditionNameOutput GetDefaultEditionName();
    }
}