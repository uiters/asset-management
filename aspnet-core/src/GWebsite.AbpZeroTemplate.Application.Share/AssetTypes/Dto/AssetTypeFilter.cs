using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetTypes.Dto
{
    public class AssetTypeFilter : PagedAndSortedInputDto, IShouldNormalize
    {
        public string AssetTypeName { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "AssetTypeName";
            }
        }
    }
}
