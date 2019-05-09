using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetTypes.Dto
{
    public class AssetTypeCombobox
    {
        public AssetTypeDto AssetType { get; set; }
        public List<ComboboxItemDto> AssetTypes { get; set; }

        public AssetTypeCombobox()
        {
            AssetTypes = new List<ComboboxItemDto>();
        }
    }
}
