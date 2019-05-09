using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Depreciations.Dto;
using System.Threading.Tasks;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Depreciations
{
    public interface IDepreciationAppService
    {
        Task<ListResultDto<DepreciationDto>> GetDepreciationsAsync();

        Task<PagedResultDto<DepreciationListDto>> GetDepreciationsAsync(GetDepreciationInput input);

        Task<GetDepreciationOutput> GetDepreciationForEditAsync(NullableIdDto input);

        Task<DepreciationDto> CreateDepreciationAsync(CreateDepreciationInput input);

        Task<DepreciationDto> UpdateDepreciationAsync(UpdateDepreciationInput input);

        Task DeleteDepreciationAsync(EntityDto<int> input);
    }
}
