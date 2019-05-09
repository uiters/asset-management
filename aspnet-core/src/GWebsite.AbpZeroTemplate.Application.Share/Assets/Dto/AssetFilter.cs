using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto
{
    public class AssetFilter : PagedAndSortedInputDto, IShouldNormalize
    {
        public string AssetName { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "AssetName";
            }
        }
    }
}
