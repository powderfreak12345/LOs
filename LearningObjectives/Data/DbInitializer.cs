﻿using EFGetStarted.AspNetCore.NewDb.Models;
using LearningObjectives.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningObjectives.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Db context)
        {
            context.Database.EnsureCreated();

            // Look for any courses.
            if (context.Courses.Any())
            {
                return;   // DB has been seeded
            }


            // Seed some courses.  Include courses multiple semesters.  Include some identical courses that were taught in different semesters.
            // Note: Course descriptions sourced from UofU catalog.  See README.

            var courses = new CourseModel[]
            {
                new CourseModel{CourseModelID=1, Number=4540, Name="Web Software Architecture", Department="School of Computing", Year=2019, Semester="Fall", Description="Software architectures, programming models, and programming environments pertinent to developing web applications.  Topics include client-server model, multi-tier software architecture, client-side scripting (JavaScript), server-side programming (Servlets and JavaServer Pages), component reuse (JavaBeans), database connectivity (JDBC), and web servers."},
                new CourseModel{CourseModelID=2, Number=3500, Name="Software Practice I", Department="School of Computing", Year=2019, Semester="Spring", Description="Practical exposure to the process of creating large software systems, including requirements specifications, design, implementation, testing, and maintenance. Emphasis on software process, software tools (debuggers, profilers, source code repositories, test harnesses), software engineering techniques (time management, code, and documentation standards, source code management, object-oriented analysis and design), and team development practice. Much of the work will be in groups and will involve modifying preexisting software systems."},
                new CourseModel{CourseModelID=3, Number=3505, Name="Software Practice II", Department="School of Computing", Year=2019, Semester="Fall", Description="An in-depth study of traditional software development (using UML) from inception through implementation.  The entire class is team-based, and will include a project that uses an agile process."},
                new CourseModel{CourseModelID=4, Number=4540, Name="Web Software Architecture", Department="School of Computing", Year=2020, Semester="Spring", Description="Software architectures, programming models, and programming environments pertinent to developing web applications.  Topics include client-server model, multi-tier software architecture, client-side scripting (JavaScript), server-side programming (Servlets and JavaServer Pages), component reuse (JavaBeans), database connectivity (JDBC), and web servers."},
            };


            foreach (CourseModel cm in courses)
            {
                context.Courses.Add(cm);
            }

            // TODO: Figure out how to turn of IDENTITY_INSERT so that the IDs can be set explicitly for seeding.
            //       I tried the first answer (and variations thereof) from this stack post, but could not get it to work:  https://stackoverflow.com/questions/40896047/how-to-turn-on-identity-insert-in-net-core?rq=1
            
            // context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Courses ON;");
            context.SaveChanges();
            // context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Courses OFF;");

            // Seed some learning outcomes.
            var learningOutcomes = new LearningOutcomeModel[]
            {
                new LearningOutcomeModel{LearningOutcomeModelID=1, CourseModelID=1, Name="Basic HTML/CSS", Description="Students can create basic HTML pages with some CSS styling.  The use of additional tools (i.e. Bootstrap) is not required for this Learning Outcome."},
                new LearningOutcomeModel{LearningOutcomeModelID=2, CourseModelID=1, Name="Bootstrap Introduction", Description="Students can supplement HTML pages with Bootstrap components to more quickly design custom pages."},
                new LearningOutcomeModel{LearningOutcomeModelID=3, CourseModelID=2, Name="Introdution to C#", Description="Students understand the basics of C#, such as types, if statements, and try-catch blocks.  Most of these concepts will have already been covered in previous courses that used a Java developing environment."},
                new LearningOutcomeModel{LearningOutcomeModelID=4, CourseModelID=2, Name="Actions, Functions, and Delegates", Description="Students understand Actions, Functions and Delegates.  They can readily provide examples of when each should be used."},
                new LearningOutcomeModel{LearningOutcomeModelID=5, CourseModelID=3, Name="Introduction to C++", Description="Students understand the basics of C++.  This includes types, headr files, and #include statements."}
            };
            foreach (LearningOutcomeModel lom in learningOutcomes)
            {
                context.LearningOutcomes.Add(lom);
            }
            context.SaveChanges();

            // Seed some evaluation metrics
            var evaluationMetrics = new EvaluationMetricModel[]
            {
                new EvaluationMetricModel{EvaluationMetricModelID=1, LearningOutcomeModelID=1, Name="Demonstration of HTML and CSS", Description="Students demonstrate their skills by constructing two unique HTML pages. Excellent pages should include concepts shown in lecture as well as some self-taught material.", Complete=true},
                new EvaluationMetricModel{EvaluationMetricModelID=2, LearningOutcomeModelID=1, Name="Quiz on CSS Theory", Description="Students are quizzed on abstract CSS concepts such as syntax, selectors, and cascading rules.", Complete=false},
            };
            foreach (EvaluationMetricModel ev in evaluationMetrics)
            {
                context.EvaluationMetrics.Add(ev);
            }
            context.SaveChanges();
        }
    }
}
