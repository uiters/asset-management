using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class AnnouncementUser
    {
        public int AnnouncementId { get; set; }
        public string UserId { get; set; }
        public bool HasRead { get; set; }

        public Announcement Announcement { get; set; }
        public AppUser User { get; set; }
    }
}
