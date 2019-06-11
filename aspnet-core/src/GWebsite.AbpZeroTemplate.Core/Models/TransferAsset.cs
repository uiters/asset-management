using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class TransferAsset: FullAuditModel
    {
        public DateTime TransferDate { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string UnitName { get; set; }
        public string Receiver { get; set; }
        public bool IsReadonly { get; set; }
        
    }
}
