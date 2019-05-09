using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.GroupAssets.Dto
{
    public class GroupAssetDto : Entity<int>
    {
        public string GroupAssetCode { get; set; }
        public string GroupAssetName { get; set; }
        public string ParentGroupAssetCode { get; set; }
        public int DepreciationMonths { get; set; }
        public float DepreciationRateByYear { get; set; }
        public string AssetTypeCode { get; set; }
        public string AssetAcount { get; set; }
        public string DepreciationAccount { get; set; }
        public string CostsAccount { get; set; }
        public string IncomeAccount { get; set; }
        public string LiquidationCostAccount { get; set; }
    }
}
