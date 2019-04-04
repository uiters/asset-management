using System.Collections.Generic;
using Abp.Application.Services.Dto;
using GSoft.AbpZeroTemplate.Editions.Dto;

namespace GSoft.AbpZeroTemplate.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}