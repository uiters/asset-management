using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class AppRole
    {
        public AppRole()
        {
            AppUserRoles = new HashSet<AppUserRole>();
            Permissions = new HashSet<Permission>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Discriminator { get; set; }

        public ICollection<AppUserRole> AppUserRoles { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
