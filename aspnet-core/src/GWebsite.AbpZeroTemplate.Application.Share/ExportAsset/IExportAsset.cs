using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ExportAsset.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.ExportAsset
{
    public interface IExportAsset
    {
        ExportAssetDto CreateExportAsset(ExportAssetDto input);
        ExportAssetDto UpdateExportAsset(ExportAssetDto input);
        void DeleteExportAsset(int id);

        ExportAssetDto GetExportAssetForEdit(int id);
        ListResultDto<ExportAssetDto> GetExportAssetByCode(string code);
        PagedResultDto<ExportAssetDto> GetExportAssetsByFilter(ExportAssetFilter input);
        ListResultDto<ExportAssetDto> GetExportAssets();
    }
}
