using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.FixAssets.Dto
{
    public class GetFixAssetOutput
    {
        public FixAssetDto FixAsset { get; set; }
        public List<ComboboxItemDto> FixAssets { get; set; }

        public GetFixAssetOutput()
        {
            FixAssets = new List<ComboboxItemDto>();
        }
    }
}
