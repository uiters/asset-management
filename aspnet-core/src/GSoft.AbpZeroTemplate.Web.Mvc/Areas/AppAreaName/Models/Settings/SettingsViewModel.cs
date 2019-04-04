using System.Collections.Generic;
using Abp.Application.Services.Dto;
using GSoft.AbpZeroTemplate.Configuration.Tenants.Dto;

namespace GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}