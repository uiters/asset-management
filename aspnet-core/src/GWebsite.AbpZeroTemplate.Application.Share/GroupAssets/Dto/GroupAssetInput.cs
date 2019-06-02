using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.GroupAssets.Dto
{
    public class GroupAssetInput : Entity<int>
    {
        [Required]
        public string GroupAssetCode { get; set; }
        [Required]
        public string GroupAssetName { get; set; }
        public string ParentGroupAssetCode { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int DepreciationMonths { get; set; }
        [Range(0, float.MaxValue)]
        public float DepreciationRateByYear { get; set; }
        [Required]
        public string AssetTypeCode { get; set; }
        [Required]
        public string AssetAcount { get; set; }
        [Required]
        public string DepreciationAccount { get; set; }
        [Required]
        public string CostsAccount { get; set; }
        [Required]
        public string IncomeAccount { get; set; }
        [Required]
        public string LiquidationCostAccount { get; set; }
        public bool IsReadonly { get; set; }

    }
}
