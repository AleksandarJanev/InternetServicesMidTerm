using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using midTerm.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace midTerm.Data
{
    public class midTermDbContext : DbContext
    {
        public midTermDbContext(DbContextOptions<midTermDbContext> options)
        : base(options)
        {
        }

        public DbSet<Answers> Answers { get; set; }
        public DbSet<SurveyUser> SurveyUsers { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurveyUser>(surveyUser =>
            {
                surveyUser.Property(p => p.Id).IsRequired();
                surveyUser.HasKey(p => p.Id);
                surveyUser.Property(p => p.FirstName).HasMaxLength(600).IsRequired();
                surveyUser.Property(p => p.LastName).HasMaxLength(600).IsRequired();
                surveyUser.Property(p => p.Country).IsRequired();
                surveyUser.Property(p => p.DoB).IsRequired();
                surveyUser.Property(p => p.Gender).IsRequired();

            });

            modelBuilder.Entity<Answers>(answer =>
            {
                answer.Property(p => p.Id).IsRequired();
                answer.HasKey(p => p.Id);

                answer.HasOne(p => p.User);

            });
        }
    }
}
