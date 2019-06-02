using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto
{
    /// <summary>
    /// For view, update
    /// </summary>
    public class AssetDto : Entity<int>
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
        public bool IsReadonly { get; set; }

    }
}
