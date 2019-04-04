using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Layout;
using GSoft.AbpZeroTemplate.Web.Session;
using GSoft.AbpZeroTemplate.Web.Views;

namespace GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameFooter
{
    public class AppAreaNameFooterViewComponent : AbpZeroTemplateViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppAreaNameFooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
