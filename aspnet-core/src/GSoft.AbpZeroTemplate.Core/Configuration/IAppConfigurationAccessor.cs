using Microsoft.Extensions.Configuration;

namespace GSoft.AbpZeroTemplate.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
