using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class AppUserRole : Entity<int>
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string AppUserId { get; set; }
        public string IdentityRoleId { get; set; }

        public AppUser AppUser { get; set; }
        public AppRole IdentityRole { get; set; }
    }
}
