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

        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<LearningOutcomeModel> LearningOutcomes { get; set; }
        public DbSet<EvaluationMetricModel> EvaluationMetrics { get; set; }
    }
}
