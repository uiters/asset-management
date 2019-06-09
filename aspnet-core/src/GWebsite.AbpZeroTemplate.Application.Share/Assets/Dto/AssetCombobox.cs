using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto
{
    public class AssetCombobox
    {
        //public AssetDto Asset { get; set; }
        public List<ComboboxItemDto> Assets { get; set; }

        public AssetCombobox()
        {
            Assets = new List<ComboboxItemDto>();
        }
    }
}
