using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlinePollingSystem.Models;

namespace OnlinePollingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserActivity>()
                .HasKey(sc => new { sc.UserId, sc.PollId });

            /*builder.Entity<UserActivity>()
                .HasOne<ApplicationUser>(i => i.User)
                .WithMany(i => i.UserActivities)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);*/

            /*builder.Entity<UserActivity>()
                .HasOne<Poll>(i => i.Poll)]
                .WithMany(i => i.UserActivities)
                .HasForeignKey(i => i.PollId)
                .OnDelete(DeleteBehavior.Cascade);*/

            /*builder.Entity<ApplicationUser>()
                .HasMany<Poll>(au => au.Polls)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);*/

            base.OnModelCreating(builder);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
    }
}
