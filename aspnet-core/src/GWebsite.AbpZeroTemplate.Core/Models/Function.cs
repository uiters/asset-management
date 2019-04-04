using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class Function : Entity<string>
    {
        public Function()
        {
            InverseParent = new HashSet<Function>();
            Permissions = new HashSet<Permission>();
        }
        public string Name { get; set; }
        public string Url { get; set; }
        public int DisplayOrder { get; set; }
        public string ParentId { get; set; }
        public bool Status { get; set; }
        public string IconCss { get; set; }

        public Function Parent { get; set; }
        public ICollection<Function> InverseParent { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
