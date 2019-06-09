using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Application.Share.Units.Dto
{
    public class UnitCombobox
    {
        //public UnitDto Unit { get; set; }
        public List<ComboboxItemDto> Units { get; set; }

        public UnitCombobox()
        {
            Units = new List<ComboboxItemDto>();
        }
    }
}
