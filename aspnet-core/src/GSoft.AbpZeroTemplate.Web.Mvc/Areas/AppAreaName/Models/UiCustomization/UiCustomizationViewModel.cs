using GSoft.AbpZeroTemplate.Configuration.Dto;

namespace GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.UiCustomization
{
    public class UiCustomizationViewModel
    {
        public UiCustomizationSettingsEditDto Settings { get; set; }

        public bool HasUiCustomizationPagePermission { get; set; }
    }
}
