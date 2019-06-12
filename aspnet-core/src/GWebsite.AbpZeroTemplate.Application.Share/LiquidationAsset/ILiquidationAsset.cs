using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.LiquidationAsset.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.LiquidationAsset
{
    public interface ILiquidationAsset
    {
        LiquidationAssetDto CreateLiquidationAsset(LiquidationAssetDto input);
        LiquidationAssetDto UpdateLiquidationAsset(LiquidationAssetDto input);
        void DeleteLiquidationAsset(int id);

        LiquidationAssetDto GetLiquidationAssetForEdit(int id);
        ListResultDto<LiquidationAssetDto> GetLiquidationAssetByCode(string code);
        PagedResultDto<LiquidationAssetDto> GetLiquidationAssetsByFilter(LiquidationAssetFilter input);
        ListResultDto<LiquidationAssetDto> GetLiquidationAssets();
    }
}
