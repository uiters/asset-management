using Abp.Modules;
using Abp.Reflection.Extensions;

namespace GWebsite.AbpZeroTemplate.Web.Core
{
    public class GWebsiteWebCoreModule : AbpModule
    {
        public GWebsiteWebCoreModule() { }

        public override void Initialize()
        {
            
        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GWebsiteWebCoreModule).GetAssembly());
        }
    }
}
