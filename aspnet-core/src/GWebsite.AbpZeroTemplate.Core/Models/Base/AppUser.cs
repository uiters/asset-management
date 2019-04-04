using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class AppUser
    {
        public AppUser()
        {
            AnnouncementUsers = new HashSet<AnnouncementUser>();
            Announcements = new HashSet<Announcement>();
            AppUserClaims = new HashSet<AppUserClaim>();
            AppUserLogins = new HashSet<AppUserLogin>();
            AppUserRoles = new HashSet<AppUserRole>();
        }

        public string Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Status { get; set; }
        public bool? Gender { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public bool? StatusFramework { get; set; }
        public string Dxsurrogate { get; set; }
        public string Surrogate { get; set; }
        public string DxcontactPerson { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string ContractId { get; set; }
        public string TaxCode { get; set; }
        public decimal? Value { get; set; }
        public int? ExpContract { get; set; }
        public DateTime? SignContractDt { get; set; }
        public DateTime? ChargeDt { get; set; }
        public string Notes { get; set; }
        public string RecordStatus { get; set; }
        public string MakerId { get; set; }
        public string DepId { get; set; }
        public DateTime? CreateDt { get; set; }
        public string AuthStatus { get; set; }
        public string CheckId { get; set; }
        public DateTime? ApproveDt { get; set; }
        public string EditorId { get; set; }
        public DateTime? EditorDt { get; set; }
        public string XmlTemp { get; set; }
        public string DataTemp { get; set; }
        public DateTime? ActiveDt { get; set; }
        public DateTime? ExpireDt { get; set; }
        public string Website { get; set; }
        public string FtpUser { get; set; }
        public string FtpPassword { get; set; }
        public string LinkAzure { get; set; }
        public string SqlUser { get; set; }
        public string SqlPass { get; set; }
        public string ValueString1 { get; set; }
        public string ValueString2 { get; set; }
        public string PriceCode { get; set; }

        public ICollection<AnnouncementUser> AnnouncementUsers { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
        public ICollection<AppUserClaim> AppUserClaims { get; set; }
        public ICollection<AppUserLogin> AppUserLogins { get; set; }
        public ICollection<AppUserRole> AppUserRoles { get; set; }
    }
}
