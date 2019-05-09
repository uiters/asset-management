using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetTypes.Dto
{
    public class AssetTypeDto : Entity<int>
    {
        public string AssetTypeCode { get; set; }
        public string AssetTypeName { get; set; }
    }
}
