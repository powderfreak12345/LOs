﻿// <auto-generated />
using LearningObjectives.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LearningObjectives.Migrations
{
    [DbContext(typeof(Db))]
    [Migration("20190926233634_InitialCreateCoursesDB")]
    partial class InitialCreateCoursesDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDb.Models.Course", b =>
                {
                    b.Property<int>("CourseID");

                    b.Property<string>("Department");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Number");

                    b.Property<string>("Semester");

                    b.Property<int>("Year");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDb.Models.LearningOutcome", b =>
                {
                    b.Property<int>("LearningOutcomeID");

                    b.Property<int>("CourseID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("LearningOutcomeID");

                    b.HasIndex("CourseID");

                    b.ToTable("LearningOutcomes");
                });

            modelBuilder.Entity("LearningObjectives.Models.EvaluationMetric", b =>
                {
                    b.Property<int>("EvaluationMetricID");

                    b.Property<bool>("Complete");

                    b.Property<string>("Description");

                    b.Property<int>("LearningOutcomeID");

                    b.Property<string>("Name");

                    b.HasKey("EvaluationMetricID");

                    b.HasIndex("LearningOutcomeID");

                    b.ToTable("EvaluationMetrics");
                });

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDb.Models.LearningOutcome", b =>
                {
                    b.HasOne("EFGetStarted.AspNetCore.NewDb.Models.Course", "Course")
                        .WithMany("LearningOutcomes")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LearningObjectives.Models.EvaluationMetric", b =>
                {
                    b.HasOne("EFGetStarted.AspNetCore.NewDb.Models.LearningOutcome", "LearningOutcome")
                        .WithMany("EvaluationMetrics")
                        .HasForeignKey("LearningOutcomeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
