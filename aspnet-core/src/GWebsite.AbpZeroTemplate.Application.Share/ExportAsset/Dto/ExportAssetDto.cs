using Abp.Domain.Entities;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.ExportAsset.Dto
{
    public class ExportAssetDto : Entity<int>
    {
        public DateTime ExportDate { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string UnitName { get; set; }
        public string User { get; set; }
        public bool IsReadonly { get; set; }
    }
}
