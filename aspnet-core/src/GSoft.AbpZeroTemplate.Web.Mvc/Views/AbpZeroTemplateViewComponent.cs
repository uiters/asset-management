using Abp.AspNetCore.Mvc.ViewComponents;

namespace GSoft.AbpZeroTemplate.Web.Views
{
    public abstract class AbpZeroTemplateViewComponent : AbpViewComponent
    {
        protected AbpZeroTemplateViewComponent()
        {
            LocalizationSourceName = AbpZeroTemplateConsts.LocalizationSourceName;
        }
    }
}