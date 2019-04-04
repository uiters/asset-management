using System.Collections.Generic;
using Abp.Localization;
using GSoft.AbpZeroTemplate.Install.Dto;

namespace GSoft.AbpZeroTemplate.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
