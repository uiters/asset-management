using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class Announcement : Entity<int>
    {
        public Announcement()
        {
            AnnouncementUsers = new HashSet<AnnouncementUser>();
        }
        
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public string UserId { get; set; }

        public AppUser User { get; set; }
        public ICollection<AnnouncementUser> AnnouncementUsers { get; set; }
    }
}
