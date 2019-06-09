using System;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.FixAssets.Dto
{
    public class UpdateFixAssetInput
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string AssetCode { get; set; }
        public DateTime DayBeginFix { get; set; }
        public DateTime DayDoneFixed { get; set; }
        public int Cost { get; set; }
        public string Proposer { get; set; }
        public string Curator { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public int? ParentId { get; set; }
        public bool Status { get; set; }
    }
}
