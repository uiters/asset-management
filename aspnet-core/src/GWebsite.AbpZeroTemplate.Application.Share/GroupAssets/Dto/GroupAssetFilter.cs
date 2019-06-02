using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.GroupAssets.Dto
{
    public class GroupAssetFilter : PagedAndSortedInputDto, IShouldNormalize
    {
        public string GroupAssetName { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "GroupAssetName";
            }
        }
    }
}
