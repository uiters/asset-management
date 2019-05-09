using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetTypes.Dto
{
    public class AssetTypeInput
    {
        [Required]
        public string AssetTypeCode { get; set; }
        [Required]
        public string AssetTypeName { get; set; }
    }
}
