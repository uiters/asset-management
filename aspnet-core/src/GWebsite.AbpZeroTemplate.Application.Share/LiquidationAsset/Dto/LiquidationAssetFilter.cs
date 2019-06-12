using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.LiquidationAsset.Dto
{
    public class LiquidationAssetFilter : PagedAndSortedInputDto, IShouldNormalize
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
