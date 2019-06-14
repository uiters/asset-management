using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.EvictionAsset.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.EvictionAsset
{
    public interface IEvictionAsset
    {
        EvictionAssetDto CreateEvictionAsset(EvictionAssetDto input);
        EvictionAssetDto UpdateEvictionAsset(EvictionAssetDto input);
        void DeleteEvictionAsset(int id);

        EvictionAssetDto GetEvictionAssetForEdit(int id);
        ListResultDto<EvictionAssetDto> GetEvictionAssetByCode(string code);
        PagedResultDto<EvictionAssetDto> GetEvictionAssetsByFilter(EvictionAssetFilter input);
        ListResultDto<EvictionAssetDto> GetEvictionAssets();
    }
}
