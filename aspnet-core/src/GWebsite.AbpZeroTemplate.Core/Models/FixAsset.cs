using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class FixAsset : FullAuditModel
    {
        public string AssetCode { get; set; }
        public DateTime DayBeginFix { get; set; }
        public DateTime DayDoneFixed { get; set; }
        public int Cost { get; set; }
        public string Proposer { get; set; }
        public string Curator { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public bool Status { get; set; }
    }
}
