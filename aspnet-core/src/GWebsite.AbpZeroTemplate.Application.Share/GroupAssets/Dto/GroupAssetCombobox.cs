using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Application.Share.GroupAssets.Dto
{
    public class GroupAssetCombobox
    {
        public GroupAssetDto GroupAsset { get; set; }
        public List<ComboboxItemDto> GroupAssets { get; set; }

        public GroupAssetCombobox()
        {
            GroupAssets = new List<ComboboxItemDto>();
        }
    }
}
