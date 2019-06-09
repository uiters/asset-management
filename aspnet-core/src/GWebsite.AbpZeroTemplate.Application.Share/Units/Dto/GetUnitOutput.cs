using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.Units.Dto
{
    public class GetUnitOutput
    {
        public UnitDto Unit { get; set; }
        public List<ComboboxItemDto> Units { get; set; }

        public GetUnitOutput()
        {
            Units = new List<ComboboxItemDto>();
        }
    }
}
