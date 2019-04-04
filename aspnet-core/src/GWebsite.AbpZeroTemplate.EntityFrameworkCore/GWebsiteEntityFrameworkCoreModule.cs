using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.Reflection.Extensions;
using Abp.Zero;
using Abp.Zero.EntityFrameworkCore;
using Castle.MicroKernel.Registration;

namespace GWebsite.AbpZeroTemplate.EntityFrameworkCore
{
    [DependsOn(typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class GWebsiteEntityFrameworkCoreModule : AbpModule
    {
        public GWebsiteEntityFrameworkCoreModule() { }

        public override void Initialize()
        {
           
        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GWebsiteEntityFrameworkCoreModule).GetAssembly());
        }
    }
}
