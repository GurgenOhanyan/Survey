using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Survey.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Survey.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Models.Survey> Survey { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            string connectionString = configBuilder.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasKey(c => new
            {
                c.Id,
                c.Name
            });

            modelBuilder.Entity<Models.Survey>()
             .HasOne(x => x.Company)
            .WithOne(c => c.Survey)
            .HasForeignKey<Models.Survey>(p => new { p.CompanyId, p.CompanyName });

            modelBuilder.Entity<QuestionType>()
                .Property(q => q.Name).HasConversion<string>();

        }
    }
}
