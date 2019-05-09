using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetTypes.Dto
{
    public class AssetTypeFilter : PagedAndSortedInputDto
    {
        public string AssetTypeName { get; set; }
    }
}
