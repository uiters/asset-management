using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Depreciations.Dto
{
    /// <summary>
    /// <model cref="Depreciation"></model>
    /// </summary>
    public class DepreciationFilter : PagedAndSortedInputDto
    {
        public string DepreciationCode { get; set; }
        public string AssetCode { get; set; }
        //public DateTime DayBeginCalculateDepreciation { get; set; }
        public int DepreciationMonths { get; set; }
        public float DepreciatedValue { get; set; }
        public float DepreciationRateByYear { get; set; }
        public float RemainingValue { get; set; }
        public bool IsDeleted { get; set; }
    }
}
