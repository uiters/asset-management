using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.GroupAssets.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.GroupAssets
{
    public interface IGroupAssetAppService
    {
        GroupAssetDto CreateGroupAsset(GroupAssetInput input);
        GroupAssetDto UpdateGroupAsset(GroupAssetInput input);
        void DeleteGroupAsset(int id);

        GroupAssetDto GetGroupAssetForEdit(int id);
        GroupAssetDto GroupAssetByCode(string code);

        PagedResultDto<GroupAssetDto> GetGroupAssetsByFilter(GroupAssetFilter input);
        ListResultDto<GroupAssetDto> GetGroupAssets();
        GroupAssetCombobox GetGroupAssetCombobox(int? id);
    }
}
