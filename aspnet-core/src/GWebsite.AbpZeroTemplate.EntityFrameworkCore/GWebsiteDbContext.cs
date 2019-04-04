using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using Abp.Zero.EntityFrameworkCore;
using GWebsite.AbpZeroTemplate.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GWebsite.AbpZeroTemplate.EntityFrameworkCore
{
    public abstract class GWebsiteDbContext<TTenant, TRole, TUser, TSelf> : AbpZeroDbContext<TTenant, TRole, TUser, TSelf>
        where TTenant : AbpTenant<TUser>
        where TRole : AbpRole<TUser>
        where TUser : AbpUser<TUser>
        where TSelf : GWebsiteDbContext<TTenant, TRole, TUser, TSelf>
    {
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<AnnouncementUser> AnnouncementUsers { get; set; }
        public virtual DbSet<AppRole> AppRoles { get; set; }
        public virtual DbSet<AppUserClaim> AppUserClaims { get; set; }
        public virtual DbSet<AppUserLogin> AppUserLogins { get; set; }
        public virtual DbSet<AppUserRole> AppUserRoles { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<MenuClient> MenuClients { get; set; }
        public virtual DbSet<DemoModel> DemoModels { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        /// <summary>
        /// GPermissions dùng cho bên Gwebsite
        /// </summary>
        public virtual DbSet<Permission> GPermissions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        protected GWebsiteDbContext(DbContextOptions<TSelf> options)
            : base(options)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Announcement>(entity =>
            {
                //entity.HasIndex(e => e.UserId)
                //    .HasName("IX_UserId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.Announcements_dbo.AppUsers_AppUser_Id");
            });

            modelBuilder.Entity<AnnouncementUser>(entity =>
            {
                entity.HasKey(e => new { e.AnnouncementId, e.UserId });

                //entity.HasIndex(e => e.AnnouncementId)
                //    .HasName("IX_AnnouncementId");

                //entity.HasIndex(e => e.UserId)
                //    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Announcement)
                    .WithMany(p => p.AnnouncementUsers)
                    .HasForeignKey(d => d.AnnouncementId)
                    .HasConstraintName("FK_dbo.AnnouncementUsers_dbo.Announcements_AnnouncementId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AnnouncementUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AnnouncementUsers_dbo.AppUsers_UserId");
            });

            modelBuilder.Entity<AppRole>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<AppUserClaim>(entity =>
            {
                entity.HasKey(e => e.UserId);

                //entity.HasIndex(e => e.AppUserId)
                //    .HasName("IX_AppUser_Id");

                entity.Property(e => e.UserId)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.AppUserId)
                    .HasColumnName("AppUser_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.AppUserClaims)
                    .HasForeignKey(d => d.AppUserId)
                    .HasConstraintName("FK_dbo.AppUserClaims_dbo.AppUsers_AppUser_Id");
            });

            modelBuilder.Entity<AppUserLogin>(entity =>
            {
                entity.HasKey(e => e.UserId);

                //entity.HasIndex(e => e.AppUserId)
                //    .HasName("IX_AppUser_Id");

                entity.Property(e => e.UserId)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.AppUserId)
                    .HasColumnName("AppUser_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.AppUserLogins)
                    .HasForeignKey(d => d.AppUserId)
                    .HasConstraintName("FK_dbo.AppUserLogins_dbo.AppUsers_AppUser_Id");
            });

            modelBuilder.Entity<AppUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                //entity.HasIndex(e => e.AppUserId)
                //    .HasName("IX_AppUser_Id");

                //entity.HasIndex(e => e.IdentityRoleId)
                //    .HasName("IX_IdentityRole_Id");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.Property(e => e.AppUserId)
                    .HasColumnName("AppUser_Id")
                    .HasMaxLength(128);

                entity.Property(e => e.IdentityRoleId)
                    .HasColumnName("IdentityRole_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.AppUserRoles)
                    .HasForeignKey(d => d.AppUserId)
                    .HasConstraintName("FK_dbo.AppUserRoles_dbo.AppUsers_AppUser_Id");

                entity.HasOne(d => d.IdentityRole)
                    .WithMany(p => p.AppUserRoles)
                    .HasForeignKey(d => d.IdentityRoleId)
                    .HasConstraintName("FK_dbo.AppUserRoles_dbo.AppRoles_IdentityRole_Id");
            });

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveDt)
                    .HasColumnName("ActiveDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Address).HasMaxLength(256);

                entity.Property(e => e.ApproveDt)
                    .HasColumnName("ApproveDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.ChargeDt)
                    .HasColumnName("ChargeDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CheckId).HasColumnName("CheckID");

                entity.Property(e => e.ContractId).HasColumnName("ContractID");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CreateDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepId).HasColumnName("DepID");

                entity.Property(e => e.DxcontactPerson).HasColumnName("DXContactPerson");

                entity.Property(e => e.Dxsurrogate).HasColumnName("DXSurrogate");

                entity.Property(e => e.EditorDt)
                    .HasColumnName("EditorDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditorId).HasColumnName("EditorID");

                entity.Property(e => e.ExpireDt)
                    .HasColumnName("ExpireDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.MakerId).HasColumnName("MakerID");

                entity.Property(e => e.SignContractDt)
                    .HasColumnName("SignContractDT")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                //entity.HasIndex(e => e.ParentId)
                //    .HasName("IX_ParentId");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasMaxLength(256);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_dbo.Functions_dbo.Functions_ParentId");
            });

            modelBuilder.Entity<MenuClient>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(256);

                entity.Property(e => e.MetaDescription).HasMaxLength(256);

                entity.Property(e => e.MetaKeyword).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });


            modelBuilder.Entity<Permission>(entity =>
            {
                //entity.HasIndex(e => e.FunctionId)
                //    .HasName("IX_FunctionId");

                //entity.HasIndex(e => e.RoleId)
                //    .HasName("IX_RoleId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FunctionId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.FunctionId)
                    .HasConstraintName("FK_dbo.Permissions_dbo.Functions_FunctionId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.Permissions_dbo.AppRoles_RoleId");
            });

        }
    }
}
