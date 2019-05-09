using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets
{
    public interface IAssetAppService
    {
        AssetDto CreateAsset(AssetDtoInput input);
        AssetDto UpdateAsset(AssetDtoInput input);
        void DeleteAsset(int id);

        AssetDto GetAssetForEdit(int id);
        AssetDto GetAssetByCode(string code);
        PagedResultDto<AssetDto> GetAssetsByFilter(AssetFilter input);
        ListResultDto<AssetDto> GetAssets();
    }
}
