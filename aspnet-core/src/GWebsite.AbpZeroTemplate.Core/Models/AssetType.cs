using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class AssetType : FullAuditModel
    {
        public string AssetTypeCode { get; set; }
        public string AssetTypeName { get; set; }
        public bool IsReadonly { get; set; }
    }
}
