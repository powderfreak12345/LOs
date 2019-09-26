using EFGetStarted.AspNetCore.NewDb.Models;
using LearningObjectives.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningObjectives.Data
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<LearningOutcome> LearningOutcomes { get; set; }
        public DbSet<EvaluationMetric> EvaluationMetrics { get; set; }
    }
}
