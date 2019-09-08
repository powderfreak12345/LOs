using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LearningObjectives.Models;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class LearningOutcomeContext : DbContext
    {
        public LearningOutcomeContext(DbContextOptions<LearningOutcomeContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Make the ID columns for both models be auto-generated.
            modelBuilder.Entity<CourseModel>().Property(p => p.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<LearningOutcomeModel>().Property(p => p.ID).ValueGeneratedOnAdd();

            // Requires that any course entering the database has a Number.
            modelBuilder.Entity<CourseModel>(entity =>
            {
                entity.Property(e => e.Number).IsRequired();
            });

        }


        public DbSet<CourseModel> Courses { get;  set; }

        public DbSet<LearningOutcomeModel> LearningOutcomes { get; set; }
    }
}
