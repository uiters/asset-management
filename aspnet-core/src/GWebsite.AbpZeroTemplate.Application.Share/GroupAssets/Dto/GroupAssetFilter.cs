using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.GroupAssets.Dto
{
    public class GroupAssetFilter : PagedAndSortedInputDto
    {
        public string GroupAssetName { get; set; }
    }
}
