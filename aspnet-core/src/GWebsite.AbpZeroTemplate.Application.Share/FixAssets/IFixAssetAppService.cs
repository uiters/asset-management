using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.FixAssets.Dto;
using System.Threading.Tasks;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.FixAssets
{
    public interface IFixAssetAppService
    {
        Task<ListResultDto<FixAssetDto>> GetFixAssetsAsync();

        Task<PagedResultDto<FixAssetListDto>> GetFixAssetsAsync(GetFixAssetInput input);

        Task<GetFixAssetOutput> GetFixAssetForEditAsync(NullableIdDto input);

        Task<FixAssetDto> CreateFixAssetAsync(CreateFixAssetInput input);

        Task<FixAssetDto> UpdateFixAssetAsync(UpdateFixAssetInput input);

        Task DeleteFixAssetAsync(EntityDto<int> input);
    }
}
