using HerIsCepteAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HerIsCepteAdmin.DAL
{
    public class DataContext : DbContext
    {
        public DataContext()
    : base("HerIsCepteEntities") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Roles)// user can have many roles
            //    .WithMany(r => r.Users)// role contains multiple users in basic
            //    .Map(m =>
            //    {
            //        m.ToTable("UserRoles");
            //        m.MapLeftKey("UserId");
            //        m.MapRightKey("RoleId");
            //    });
        }

        public DbSet<UserTable> Users { get; set; }
        public DbSet<Admins> Admin { get; set; }
        public DbSet<DistrictsAndCities> DistrictsAndCities { get; set; }
        public DbSet<TopCategories> TopCategories { get; set; }
        public DbSet<SubCategories> SubCategories { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<QuestionAnswers> QuestionAnswers { get; set; }
        public DbSet<AdvertisementQuestion> AdvertisementQuestion { get; set; }
        public DbSet<Advertisements> Advertisements { get; set; }
        public DbSet<AdvertisementDocuments> AdvertisementDocuments { get; set; }
        public DbSet<FavoriteAdvertisements> FavoriteAdvertisements { get; set; }
        public DbSet<Offers> Offers { get; set; }
        public DbSet<Definitions> Definitions { get; set; }
        public DbSet<FavoriteCategories> FavoriteCategories { get; set; }
        public DbSet<CorporateDocuments> CorporateDocuments { get; set; }
        public DbSet<CorporateApplications> CorporateApplications { get; set; }
        public DbSet<NotificationSettings> NotificationSettings { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Help> Help { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<BlogPhoto> BlogPhoto { get; set; }
        public DbSet<SEO> SEO { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Packages> Packages { get; set; }
        public DbSet<PackageTransactions> PackageTransactions { get; set; }
        public DbSet<FavoriteLocations> FavoriteLocations { get; set; }
    }
}