using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TransferAsset.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.TransferAsset
{
    public interface ITransferAsset
    {
        TransferAssetDto CreateTransferAsset(TransferAssetDto input);
        TransferAssetDto UpdateTransferAsset(TransferAssetDto input);
        void DeleteTransferAsset(int id);

        TransferAssetDto GetTransferAssetForEdit(int id);
        ListResultDto<TransferAssetDto> GetTransferAssetByCode(string code);
        PagedResultDto<TransferAssetDto> GetTransferAssetsByFilter(TransferAssetFilter input);
        ListResultDto<TransferAssetDto> GetTransferAssets();
    }
}
