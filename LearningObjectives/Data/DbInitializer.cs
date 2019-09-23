using EFGetStarted.AspNetCore.NewDb.Models;
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
                new CourseModel{CourseModelID=1, Number=2100, Name="Discrete Structures", Department="School of Computing", Year=2019, Semester="Fall", Description="Introduction to propositional logic, predicate logic, formal logical arguments, finite sets, functions, relations, inductive proofs, recurrence relations, graphs, probability, and their applications to Computer Science."},
                new CourseModel{CourseModelID=2, Number=2420, Name="Introduction to Algorithms & Data Structures", Department="School of Computing", Year=2019, Semester="Fall", Description="This course provides an introduction to the problem of engineering computational efficiency into programs. Students will learn about classical algorithms (including sorting, searching, and graph traversal), data structures (including stacks, queues, linked lists, trees, hash tables, and graphs), and analysis of program space and time requirements. Students will complete extensive programming exercises that require the application of elementary techniques from software engineering."},
                new CourseModel{CourseModelID=3, Number=3500, Name="Software Practice I", Department="School of Computing", Year=2019, Semester="Spring", Description="Practical exposure to the process of creating large software systems, including requirements specifications, design, implementation, testing, and maintenance. Emphasis on software process, software tools (debuggers, profilers, source code repositories, test harnesses), software engineering techniques (time management, code, and documentation standards, source code management, object-oriented analysis and design), and team development practice. Much of the work will be in groups and will involve modifying preexisting software systems."},
                new CourseModel{CourseModelID=4, Number=4400, Name="Computer Systems", Department="School of Computing", Year=2019, Semester="Fall", Description="Introduction to computer systems from a programmer's point of view.  Machine level representations of programs, optimizing program performance, memory hierarchy, linking, exceptional control flow, measuring program performance, virtual memory, concurrent programming with threads, network programming."},
                new CourseModel{CourseModelID=5, Number=4540, Name="Web Software Architecture", Department="School of Computing", Year=2020, Semester="Spring", Description="Software architectures, programming models, and programming environments pertinent to developing web applications.  Topics include client-server model, multi-tier software architecture, client-side scripting (JavaScript), server-side programming (Servlets and JavaServer Pages), component reuse (JavaBeans), database connectivity (JDBC), and web servers."},
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
                new LearningOutcomeModel{LearningOutcomeModelID=1, CourseModelID=1, Description="Use symbolic logic to model real-world situations by converting informal language statements to propositional and predicate logic expressions, as well as apply formal methods to propositions and predicates (such as computing normal forms and calculating validity)."},
                new LearningOutcomeModel{LearningOutcomeModelID=2, CourseModelID=1, Description="Analyze problems to determine underlying recurrence relations, as well as solve such relations by rephrasing as closed formulas."},
                new LearningOutcomeModel{LearningOutcomeModelID=3, CourseModelID=1, Description="Assign practical examples to the appropriate set, function, or relation model, while employing the associated terminology and operations."},
                new LearningOutcomeModel{LearningOutcomeModelID=4, CourseModelID=1, Description="Map real-world applications to appropriate counting formalisms, including permutations and combinations of sets, as well as exercise the rules of combinatorics (such as sums, products, and inclusion-exclusion)."},
                new LearningOutcomeModel{LearningOutcomeModelID=5, CourseModelID=1, Description="Calculate probabilities of independent and dependent events, in addition to expectations of random variables."},
                new LearningOutcomeModel{LearningOutcomeModelID=6, CourseModelID=1, Description="Illustrate by example the basic terminology of graph theory, as wells as properties and special cases (such as Eulerian graphs, spanning trees, isomorphism, and planarity)."},
                new LearningOutcomeModel{LearningOutcomeModelID=7, CourseModelID=1, Description="Employ formal proof techniques (such as direct proof, proof by contradiction, induction, and the pigeonhole principle) to construct sound arguments about properties of numbers, sets, functions, relations, and graphs."},

                new LearningOutcomeModel{LearningOutcomeModelID=8, CourseModelID=2, Description="Implement, and analyze for efficiency, fundamental data structures (including lists, graphs, and trees) and algorithms (including searching, sorting, and hashing)."},
                new LearningOutcomeModel{LearningOutcomeModelID=9, CourseModelID=2, Description="Employ Big-O notation to describe and compare the asymptotic complexity of algorithms, as well as perform empirical studies to validate hypotheses about running time."},
                new LearningOutcomeModel{LearningOutcomeModelID=10, CourseModelID=2, Description="Recognize and describe common applications of abstract data types (including stacks, queues, priority queues, sets, and maps)."},
                new LearningOutcomeModel{LearningOutcomeModelID=11, CourseModelID=2, Description="Apply algorithmic solutions to real-world data."},
                new LearningOutcomeModel{LearningOutcomeModelID=12, CourseModelID=2, Description="Use generics to abstract over functions that differ only in their types."},
                new LearningOutcomeModel{LearningOutcomeModelID=13, CourseModelID=2, Description="Appreciate the collaborative nature of computer science by discussing the benefits of pair programming."},

                new LearningOutcomeModel{LearningOutcomeModelID=14, CourseModelID=3, Description="Design and implement large and complex software systems (including concurrent software) through the use of process models (such as waterfall and agile), libraries (both standard and custom), and modern software development tools (such as debuggers, profilers, and revision control systems)."},
                new LearningOutcomeModel{LearningOutcomeModelID=15, CourseModelID=3, Description="Perform input validation and error handling, as well as employ advanced testing principles and tools to systematically evaluate software."},
                new LearningOutcomeModel{LearningOutcomeModelID=16, CourseModelID=3, Description="Apply the model-view-controller pattern and event handling fundamentals to create a graphical user interface."},
                new LearningOutcomeModel{LearningOutcomeModelID=17, CourseModelID=3, Description="Exercise the client-server model and high-level networking APIs to build a web-based software system."},
                new LearningOutcomeModel{LearningOutcomeModelID=18, CourseModelID=3, Description="Operate a modern relational database to define relations, as well as store and retrieve data."},
                new LearningOutcomeModel{LearningOutcomeModelID=19, CourseModelID=3, Description="Appreciate the collaborative nature of software development by discussing the benefits of peer code reviews."},
                
                new LearningOutcomeModel{LearningOutcomeModelID=20, CourseModelID=4, Description="Explain the objectives and functions of abstraction layers in modern computing systems, including operating systems, programming languages, compilers, and applications."},
                new LearningOutcomeModel{LearningOutcomeModelID=21, CourseModelID=4, Description="Understand cross-layer communications and how each layer of abstraction is implemented in the next layer of abstraction (such as how C programs are translated into assembly code and how C library allocators are implemented in terms of operating system memory management)."},
                new LearningOutcomeModel{LearningOutcomeModelID=22, CourseModelID=4, Description="Analyze how the performance characteristics of one layer of abstraction affect the layers above it (such as how caching and services of the operating system affect the performance of C programs)."},
                new LearningOutcomeModel{LearningOutcomeModelID=23, CourseModelID=4, Description="Construct applications using operating-system concepts (such as processes, threads, signals, virtual memory, I/O)."},
                new LearningOutcomeModel{LearningOutcomeModelID=24, CourseModelID=4, Description="Synthesize operating-system and networking facilities to build concurrent, communicating applications."},
                new LearningOutcomeModel{LearningOutcomeModelID=25, CourseModelID=4, Description="Implement reliable concurrent and parallel programs using appropriate synchronization constructs."},

                new LearningOutcomeModel{LearningOutcomeModelID=26, CourseModelID=5, Description="Construct web pages using modern HTML and CSS practices, including modern frameworks."},
                new LearningOutcomeModel{LearningOutcomeModelID=27, CourseModelID=5, Description="Define accessibility and utilize techniques to create accessible web pages."},
                new LearningOutcomeModel{LearningOutcomeModelID=28, CourseModelID=5, Description="Outline and utilize MVC technologies across the “full-stack” of web design (including front-end, back-end, and databases) to create interesting web applications. Deploy an application to a “Cloud” provider."},
                new LearningOutcomeModel{LearningOutcomeModelID=29, CourseModelID=5, Description="Describe the browser security model and HTTP; utilize techniques for data validation, secure session communication, cookies, single sign-on, and separate roles."},
                new LearningOutcomeModel{LearningOutcomeModelID=30, CourseModelID=5, Description="Utilize JavaScript for simple page manipulations and AJAX for more complex/complete “single-page” applications."},
                new LearningOutcomeModel{LearningOutcomeModelID=31, CourseModelID=5, Description="Demonstrate how responsive techniques can be used to construct applications that are usable at a variety of page sizes.  Define and discuss responsive, reactive, and adaptive."},
                new LearningOutcomeModel{LearningOutcomeModelID=32, CourseModelID=5, Description="Construct a simple web-crawler for validation of page functionality and data scraping."}
            };
            foreach (LearningOutcomeModel lom in learningOutcomes)
            {
                context.LearningOutcomes.Add(lom);
            }
            context.SaveChanges();

            // Seed some evaluation metrics
            var evaluationMetrics = new EvaluationMetricModel[]
            {
                new EvaluationMetricModel{EvaluationMetricModelID=1, LearningOutcomeModelID=26, Name="Demonstration of HTML and CSS", Description="Students demonstrate their skills by constructing two unique HTML pages. Excellent pages should include concepts shown in lecture as well as some self-taught material.", Complete=true},
                new EvaluationMetricModel{EvaluationMetricModelID=2, LearningOutcomeModelID=26, Name="Quiz on CSS Theory", Description="Students are quizzed on abstract CSS concepts such as syntax, selectors, and cascading rules.", Complete=false},
            };
            foreach (EvaluationMetricModel ev in evaluationMetrics)
            {
                context.EvaluationMetrics.Add(ev);
            }
            context.SaveChanges();
        }
    }
}
