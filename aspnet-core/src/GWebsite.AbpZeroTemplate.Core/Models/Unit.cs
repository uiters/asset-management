using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Unit :FullAuditModel
    {
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string User { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public bool Status { get; set; }
    }
}
