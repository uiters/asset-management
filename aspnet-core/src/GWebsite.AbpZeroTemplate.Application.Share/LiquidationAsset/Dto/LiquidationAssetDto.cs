using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.LiquidationAsset.Dto
{
    public class LiquidationAssetDto : Entity<int>
    {
        public DateTime LiquidationDate { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string Unit { get; set; }
        public string LiquidationForm { get; set; }
        public int LiquidationCost { get; set; }
        public string Note { get; set; }
        public bool IsReadonly { get; set; }
    }
}
