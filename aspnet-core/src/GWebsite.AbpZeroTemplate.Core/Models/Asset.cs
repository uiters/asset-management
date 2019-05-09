using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Asset : Entity<int>
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
    }
}