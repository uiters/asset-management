using Abp.Domain.Entities;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.EvictionAsset.Dto
{
    public class EvictionAssetDto : Entity<int>
    {
        public DateTime EvictionDate { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string Reason { get; set; }
        public string Content { get; set; }
        public bool IsReadonly { get; set; }
    }
}
