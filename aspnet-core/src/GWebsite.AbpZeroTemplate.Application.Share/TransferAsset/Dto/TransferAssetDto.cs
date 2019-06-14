using Abp.Domain.Entities;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.TransferAsset.Dto
{
    public class TransferAssetDto : Entity<int>
    {
        public DateTime TransferDate { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string UnitName { get; set; }
        public string Receiver { get; set; }
        public bool IsReadonly { get; set; }
    }
}
