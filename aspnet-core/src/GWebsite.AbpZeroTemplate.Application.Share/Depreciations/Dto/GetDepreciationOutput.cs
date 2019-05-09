using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.Depreciations.Dto
{
    public class GetDepreciationOutput
    {
        public DepreciationDto Depreciation { get; set; }
        public List<ComboboxItemDto> Depreciations { get; set; }

        public GetDepreciationOutput()
        {
            Depreciations = new List<ComboboxItemDto>();
        }
    }
}
