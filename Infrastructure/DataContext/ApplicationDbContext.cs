using Domain.Entities;
using Domain.Entities.Advertainments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MyHome.Domain.Entities.Advertainments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Advertainment> Advertainments { get; set; }
        public DbSet<AdvertainmentFeature> AdvertainmentFeatures { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FeatureItem> FeatureItems { get; set; }
        public DbSet<FeatureItemSelect> FeatureItemSelects { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().HasMany(i => i.AppUserRoles)
                        .WithOne(i => i.User)
                        .HasForeignKey(i => i.UserId);

            builder.Entity<AppRole>().HasMany(i => i.AppUserRoles)
                        .WithOne(i => i.Role)
                        .HasForeignKey(i => i.RoleId);

            builder.Entity<Feature>().HasMany(i => i.FeatureItems)
                                     .WithOne(i => i.Feature)
                                     .HasForeignKey(i => i.FeatureId);

            builder.Entity<AppUser>().HasMany(i => i.Advertainments)
                                     .WithOne(i => i.User)
                                     .HasForeignKey(i => i.UserId);

            builder.Entity<Advertainment>().HasMany(i => i.AdvertainmentFeatures)
                                           .WithOne(i => i.Advertainment)
                                           .HasForeignKey(i => i.AdvertainmentId);

            builder.Entity<Feature>().HasMany(i => i.FeatureItems)
                                     .WithOne(i => i.Feature)
                                     .HasForeignKey(i => i.FeatureId);

            
            builder.Entity<AdvertainmentFeature>().HasOne(i => i.FeatureItem)
                                                  .WithMany(i => i.AdvertainmentFeatures)
                                                  .HasForeignKey(i => i.FeatureItemId)
                                                  .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<FeatureItem>().HasMany(i => i.FeatureItemSelects)
                                         .WithOne(i => i.FeatureItem)
                                         .HasForeignKey(i => i.FeatureItemId);

            builder.Entity<Advertainment>().HasMany(i => i.Images)
                                           .WithOne(i => i.Ad)
                                           .HasForeignKey(i => i.AdId);

            builder.Entity<AdImage>().ToTable("AdImages");
            builder.Entity<AdImage>().HasKey(i => i.Id);
        }
    }
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Data Source=DESKTOP-B2DMPTU\\SQLEXPRESS;Initial Catalog = MyHomeDb; Integrated Security = True");
            return new ApplicationDbContext(options.Options);
        }
    }
}
