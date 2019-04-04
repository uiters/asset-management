using Abp.Dependency;
using GSoft.AbpZeroTemplate.Configuration;
using GSoft.AbpZeroTemplate.Url;
using GSoft.AbpZeroTemplate.Web.Url;

namespace GSoft.AbpZeroTemplate.Web.Public.Url
{
    public class WebUrlService : WebUrlServiceBase, IWebUrlService, ITransientDependency
    {
        public WebUrlService(
            IAppConfigurationAccessor appConfigurationAccessor) :
            base(appConfigurationAccessor)
        {
        }

        public override string WebSiteRootAddressFormatKey => "App:WebSiteRootAddress";

        public override string ServerRootAddressFormatKey => "App:AdminWebSiteRootAddress";
    }
}