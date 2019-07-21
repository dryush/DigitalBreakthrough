using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Models;

namespace School.Data
{
    public class AppUser : IdentityUser<int>
    {
        public List<SchoolClass> SchoolClasses { get; set; }
        public int? ChildClassId { get; set; }
        public SchoolClass ChildClass { get; set; }

        public string FullName { get; set; }
        public List<Message> Messages { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Voicing> Voicings { get; set; }
        public DbSet<VoicingOption> VoicingOptions { get; set; }
        public DbSet<Voice> Voices { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Message> Messages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.EnableSensitiveDataLogging(true);

                optionsBuilder.EnableDetailedErrors(true);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            builder.Entity<AppUser>()
                .HasMany(a => a.SchoolClasses)
                .WithOne(c => c.Teacher)
                .HasForeignKey(a => a.TeacherId);
            builder.Entity<AppUser>()
                .HasMany(a => a.Messages)
                .WithOne(m => m.User)
                .HasForeignKey(a => a.UserId);


            builder.Entity<Discussion>()
                .HasKey(v => v.Id);
            builder.Entity<Discussion>()
                .HasMany(d => d.Voicinigs)
                .WithOne(v => v.Discussion)
                .HasForeignKey(v => v.DiscussionId);

            builder.Entity<Voicing>()
                .HasKey(v => v.Id);
            builder.Entity<Voicing>()
                .HasMany(v => v.Options)
                .WithOne(v => v.Voicing)
                .HasForeignKey(v => v.VoicingId);

            builder.Entity<VoicingOption>()
                .HasKey(v => v.Id);
            builder.Entity<VoicingOption>()
                .HasMany(v => v.Voices)
                .WithOne(o => o.Option)
                .HasForeignKey(v => v.OptionId);

            builder.Entity<Voice>()
                .HasKey(v => v.Id);

            builder.Entity<SchoolClass>()
                .HasKey(c => c.Id);
            builder.Entity<SchoolClass>()
                .HasMany( c => c.Parents)
                .WithOne( p => p.ChildClass)
                .HasForeignKey( c => c.ChildClassId);
            builder.Entity<SchoolClass>()
                .HasMany(c => c.Discussions)
                .WithOne(d => d.SchoolClass)
                .HasForeignKey(d => d.SchoolClassId);
            

            base.OnModelCreating(builder);
        }
    }
}
