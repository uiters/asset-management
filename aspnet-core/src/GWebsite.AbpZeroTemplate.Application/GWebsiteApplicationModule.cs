using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GWebsite.AbpZeroTemplate.Applications;
using GWebsite.AbpZeroTemplate.Core.Authorization;

namespace GWebsite.AbpZeroTemplate.Application
{
    public class GWebsiteApplicationModule : AbpModule
    {
        public GWebsiteApplicationModule() { }

        public override void Initialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<GWebsiteAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GWebsiteApplicationModule).GetAssembly());
        }
    }
}
