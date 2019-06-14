using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.TransferAsset.Dto
{
    public class TransferAssetFilter : PagedAndSortedInputDto, IShouldNormalize
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
