using Abp.Domain.Entities;
using System;
namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Asset : Entity<int>, ISoftDelete
    {
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string SeriCode { get; set; }
        public int OriginalPrice { get; set; }
        public DateTime DayImport { get; set; }
        public string GroupAssetCode { get; set; }
        public string Provider { get; set; }
        public DateTime WarrantyPeriod { get; set; }
        public int DepreciationMonths { get; set; }
        public float DepreciationRateByYear { get; set; }
        public bool IsDeleted { get; set; }
    }
}