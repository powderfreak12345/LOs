using EFGetStarted.AspNetCore.NewDb.Models;
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
                new CourseModel{ID=1, Number=4540, Name="Web Software Architecture", Department="School of Computing", Year=2019, Semester="Fall", Description="Software architectures, programming models, and programming environments pertinent to developing web applications.  Topics include client-server model, multi-tier software architecture, client-side scripting (JavaScript), server-side programming (Servlets and JavaServer Pages), component reuse (JavaBeans), database connectivity (JDBC), and web servers."},
                new CourseModel{ID=2, Number=3500, Name="Software Practice I", Department="School of Computing", Year=2019, Semester="Spring", Description="Practical exposure to the process of creating large software systems, including requirements specifications, design, implementation, testing, and maintenance. Emphasis on software process, software tools (debuggers, profilers, source code repositories, test harnesses), software engineering techniques (time management, code, and documentation standards, source code management, object-oriented analysis and design), and team development practice. Much of the work will be in groups and will involve modifying preexisting software systems."},
                new CourseModel{ID=3, Number=3505, Name="Software Practice II", Department="School of Computing", Year=2019, Semester="Fall", Description="An in-depth study of traditional software development (using UML) from inception through implementation.  The entire class is team-based, and will include a project that uses an agile process."},
                new CourseModel{ID=1, Number=4540, Name="Web Software Architecture", Department="School of Computing", Year=2020, Semester="Spring", Description="Software architectures, programming models, and programming environments pertinent to developing web applications.  Topics include client-server model, multi-tier software architecture, client-side scripting (JavaScript), server-side programming (Servlets and JavaServer Pages), component reuse (JavaBeans), database connectivity (JDBC), and web servers."},
            };
            foreach (CourseModel cm in courses)
            {
                context.Courses.Add(cm);
            }
            context.SaveChanges();

            // Seed some learning outcomes.
            var learningOutcomes = new LearningOutcomeModel[]
            {
                new LearningOutcomeModel{CourseInstanceID=1, Name="Basic Knowledge of HTML/CSS", Description="Students can create basic HTML pages with some CSS styling.  The use of additional tools (i.e. Bootstrap) is not required for this Learning Outcome."},
                new LearningOutcomeModel{CourseInstanceID=1, Name="Bootstrap Introduction", Description="Students can supplement HTML pages with Bootstrap components to more quickly design custom pages."},
                new LearningOutcomeModel{CourseInstanceID=2, Name="Introdution to C#", Description="Students understand the basics of C#, such as types, if statements, and try-catch blocks.  Most of these concepts will have already been covered in previous courses that used a Java developing environment."},
                new LearningOutcomeModel{CourseInstanceID=2, Name="Actions, Functions, and Delegates", Description="Students understand Actions, Functions and Delegates.  They can readily provide examples of when each should be used."},
                new LearningOutcomeModel{CourseInstanceID=3, Name="Introduction to C++", Description="Students understand the basics of C++.  This includes types, headr files, and #include statements."}
            };
            foreach (LearningOutcomeModel lom in learningOutcomes)
            {
                context.LearningOutcomes.Add(lom);
            }
            context.SaveChanges();
        }
    }
}
