using Abp.Domain.Entities;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Depreciations.Dto
{
    public class DepreciationListDto : Entity<int>
    {
        public string Name { get; set; }
        public string DepreciationCode { get; set; }
        public string AssetCode { get; set; }
        public DateTime DayBeginCalculateDepreciation { get; set; }
        public int DepreciationMonths { get; set; }
        public float DepreciatedValue { get; set; }
        public float DepreciationRateByYear { get; set; }
        public float RemainingValue { get; set; }
        public bool IsDeleted { get; set; }
        public int? ParentId { get; set; }
        public bool Status { get; set; }

        
    }
}
