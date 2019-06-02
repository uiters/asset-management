using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto
{
    public class AssetInput : Entity<int>
    {
        [Required]
        public string AssetCode { get; set; }
        [Required]
        public string AssetName { get; set; }
        public string SeriCode { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int OriginalPrice { get; set; }

        [Required]
        public DateTime DayImport { get; set; }

        [Required]
        public string GroupAssetCode { get; set; }
        public string Provider { get; set; }
        public DateTime WarrantyPeriod { get; set; }

        [Range(0, int.MaxValue)]
        public int DepreciationMonths { get; set; }
        public float DepreciationRateByYear { get; set; }
        public bool IsReadonly { get; set; }

    }
}
