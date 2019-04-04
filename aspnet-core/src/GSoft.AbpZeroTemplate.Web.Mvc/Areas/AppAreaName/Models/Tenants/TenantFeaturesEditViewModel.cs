using Abp.AutoMapper;
using GSoft.AbpZeroTemplate.MultiTenancy;
using GSoft.AbpZeroTemplate.MultiTenancy.Dto;
using GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Common;

namespace GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}