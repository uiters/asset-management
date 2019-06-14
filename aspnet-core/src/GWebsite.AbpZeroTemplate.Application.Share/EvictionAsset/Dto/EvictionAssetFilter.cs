using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.EvictionAsset.Dto
{
    public class EvictionAssetFilter : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Name { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "AssetName";
            }
        }
    }
}
