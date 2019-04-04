using System.Collections.Generic;
using Abp.Application.Services.Dto;
using GSoft.AbpZeroTemplate.Configuration.Host.Dto;
using GSoft.AbpZeroTemplate.Editions.Dto;

namespace GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }

        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}