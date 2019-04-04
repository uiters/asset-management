using Abp.Application.Navigation;

namespace GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Layout
{
    public class MenuViewModel
    {
        public UserMenu Menu { get; set; }

        public string CurrentPageName { get; set; }
    }
}