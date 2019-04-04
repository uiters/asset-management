using Abp.AutoMapper;
using GSoft.AbpZeroTemplate.Sessions.Dto;

namespace GSoft.AbpZeroTemplate.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}