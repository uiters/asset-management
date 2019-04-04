using Abp.AutoMapper;
using GSoft.AbpZeroTemplate.MultiTenancy.Dto;

namespace GSoft.AbpZeroTemplate.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}