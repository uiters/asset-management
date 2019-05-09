using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto
{
    public class AssetFilter : PagedAndSortedInputDto
    {
        public string AssetName { get; set; }
    }
}
