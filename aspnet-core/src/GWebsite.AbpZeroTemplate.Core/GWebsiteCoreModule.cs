using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero;

namespace GWebsite.AbpZeroTemplate.Application
{
    public class GWebsiteCoreModule : AbpModule
    {
        public GWebsiteCoreModule() { }

        public override void Initialize()
        {
        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GWebsiteCoreModule).GetAssembly());
        }
    }
}
