using Abp.MultiTenancy;
using GSoft.AbpZeroTemplate.Url;

namespace GSoft.AbpZeroTemplate.Web.Url
{
    public class AngularAppUrlService : AppUrlServiceBase
    {
        public override string EmailActivationRoute => "account/confirm-email";

        public override string PasswordResetRoute => "account/reset-password";

        public override string CreateMenuClient => "MenuClient/CreateMenuClient";
        //public override string CreateOrderPackage => "OrderPackage/CreateOrderPackage";
        //public override string UpdateMenuClient => "MenuClient/UpdateMenuClient";
        //public override string DeleteMenuClient => "MenuClient/DeleteMenuClient";
        public AngularAppUrlService(
                IWebUrlService webUrlService,
                ITenantCache tenantCache
            ) : base(
                webUrlService,
                tenantCache
            )
        {

        }
    }
}