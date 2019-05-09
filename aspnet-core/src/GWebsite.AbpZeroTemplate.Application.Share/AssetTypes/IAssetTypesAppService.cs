using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetTypes
{
    public interface IAssetTypesAppService
    {
        AssetTypeDto CreateAssetType(AssetTypeInput input);
        AssetTypeDto UpdateAssetType(AssetTypeInput input);
        void DeleteAssetType(int id);

        AssetTypeDto GetAssetTypeForEdit(int id);
        AssetTypeDto GetAssetTypeByCode(string code);

        PagedResultDto<AssetTypeDto> GetAssetTypesByFilter(AssetTypeFilter input);
        ListResultDto<AssetTypeDto> GetAssetTypes();
        AssetTypeCombobox GetAssetTypeCombobox(int? id);
    }
}
