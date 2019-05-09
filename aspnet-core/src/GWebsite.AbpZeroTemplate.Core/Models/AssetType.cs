using Abp.Domain.Entities;
namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class AssetType : Entity<int>, ISoftDelete
    {
        public string AssetTypeCode { get; set; }
        public string AssetTypeName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
