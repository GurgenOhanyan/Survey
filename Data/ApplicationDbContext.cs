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
    public class ApplicationDbContext : IdentityDbContext<Company,Role,string>
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionTypes> QuestionTypes { get; set; }
        public DbSet<Models.Survey> Survey { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuestionTypes>()
                .Property(q => q.Name).HasConversion<string>();

        }
    }
}
