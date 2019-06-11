using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class EvicitonAsset: FullAuditModel
    {
        public DateTime EvictionDate { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string Reason { get; set; }
        public string Content { get; set; }
        public bool IsReadonly { get; set; }

    }
}
