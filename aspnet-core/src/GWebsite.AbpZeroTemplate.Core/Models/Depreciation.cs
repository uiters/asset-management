using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Depreciation: Entity<int>
    {
        public string DepreciationCode { get; set; }
        public string AssetCode { get; set; }
        public DateTime DayBeginCalculateDepreciation { get; set; }
        public int DepreciationMonths { get; set; }
        public float DepreciatedValue { get; set; }      
        public float DepreciationRateByYear { get; set; }
        public float RemainingValue { get; set; }
    }
}
