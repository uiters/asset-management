using Abp.Domain.Entities;
using System;
namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Depreciation : Entity<int>, ISoftDelete
    {
        public string DepreciationCode { get; set; }
        public string AssetCode { get; set; }
        public DateTime DayBeginCalculateDepreciation { get; set; }
        public int DepreciationMonths { get; set; }
        public float DepreciatedValue { get; set; }
        public float DepreciationRateByYear { get; set; }
        public float RemainingValue { get; set; }
        public bool IsDeleted { get; set; }
    }
}
