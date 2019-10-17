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
            context.Database.Migrate();

            // Look for any courses.
            if (context.Courses.Any())
            {
                return;   // DB has been seeded
            }

            // Seed some courses.  Include courses multiple semesters.  Include some identical courses that were taught in different semesters.
            // Note: Course descriptions sourced from UofU catalog.  See README.
            var courses = new Course[]
            {
                new Course{CourseID=1, InstructorID="1", Number=2100, Name="Discrete Structures", Department="School of Computing", Year=2019, Semester="Fall", Description="Introduction to propositional logic, predicate logic, formal logical arguments, finite sets, functions, relations, inductive proofs, recurrence relations, graphs, probability, and their applications to Computer Science."},
                new Course{CourseID=2, InstructorID="3", Number=2420, Name="Introduction to Algorithms & Data Structures", Department="School of Computing", Year=2019, Semester="Fall", Description="This course provides an introduction to the problem of engineering computational efficiency into programs. Students will learn about classical algorithms (including sorting, searching, and graph traversal), data structures (including stacks, queues, linked lists, trees, hash tables, and graphs), and analysis of program space and time requirements. Students will complete extensive programming exercises that require the application of elementary techniques from software engineering."},
                new Course{CourseID=3, InstructorID="3", Number=3500, Name="Software Practice I", Department="School of Computing", Year=2019, Semester="Spring", Description="Practical exposure to the process of creating large software systems, including requirements specifications, design, implementation, testing, and maintenance. Emphasis on software process, software tools (debuggers, profilers, source code repositories, test harnesses), software engineering techniques (time management, code, and documentation standards, source code management, object-oriented analysis and design), and team development practice. Much of the work will be in groups and will involve modifying preexisting software systems."},
                new Course{CourseID=4, InstructorID="2", Number=3500, Name="Software Practice I", Department="School of Computing", Year=2019, Semester="Spring", Description="Practical exposure to the process of creating large software systems, including requirements specifications, design, implementation, testing, and maintenance. Emphasis on software process, software tools (debuggers, profilers, source code repositories, test harnesses), software engineering techniques (time management, code, and documentation standards, source code management, object-oriented analysis and design), and team development practice. Much of the work will be in groups and will involve modifying preexisting software systems."},
                new Course{CourseID=5, InstructorID="1", Number=4400, Name="Computer Systems", Department="School of Computing", Year=2019, Semester="Fall", Description="Introduction to computer systems from a programmer's point of view.  Machine level representations of programs, optimizing program performance, memory hierarchy, linking, exceptional control flow, measuring program performance, virtual memory, concurrent programming with threads, network programming."},
                new Course{CourseID=6, InstructorID="3", Number=4540, Name="Web Software Architecture", Department="School of Computing", Year=2020, Semester="Spring", Description="Software architectures, programming models, and programming environments pertinent to developing web applications.  Topics include client-server model, multi-tier software architecture, client-side scripting (JavaScript), server-side programming (Servlets and JavaServer Pages), component reuse (JavaBeans), database connectivity (JDBC), and web servers."},
            };

            foreach (Course cm in courses)
            {
                context.Courses.Add(cm);
            }

            context.SaveChanges();


            // Seed some course notes
            var courseNotes = new Course_Note[]
            {
                new Course_Note{CourseID=1, ApprovedByChair=false, Note="I hate teaching this course."},
                new Course_Note{CourseID=5, ApprovedByChair=true, Note="I love teaching this course."},
            };

            foreach (Course_Note note in courseNotes)
            {
                context.Course_Notes.Add(note);
            }

            context.SaveChanges();


            // Seed some learning outcomes.
            var learningOutcomes = new LearningOutcome[]
            {
                new LearningOutcome{LearningOutcomeID=1, CourseID=1, Description="Use symbolic logic to model real-world situations by converting informal language statements to propositional and predicate logic expressions, as well as apply formal methods to propositions and predicates (such as computing normal forms and calculating validity)."},
                new LearningOutcome{LearningOutcomeID=2, CourseID=1, Description="Analyze problems to determine underlying recurrence relations, as well as solve such relations by rephrasing as closed formulas."},
                new LearningOutcome{LearningOutcomeID=3, CourseID=1, Description="Assign practical examples to the appropriate set, function, or relation model, while employing the associated terminology and operations."},
                new LearningOutcome{LearningOutcomeID=4, CourseID=1, Description="Map real-world applications to appropriate counting formalisms, including permutations and combinations of sets, as well as exercise the rules of combinatorics (such as sums, products, and inclusion-exclusion)."},
                new LearningOutcome{LearningOutcomeID=5, CourseID=1, Description="Calculate probabilities of independent and dependent events, in addition to expectations of random variables."},
                new LearningOutcome{LearningOutcomeID=6, CourseID=1, Description="Illustrate by example the basic terminology of graph theory, as wells as properties and special cases (such as Eulerian graphs, spanning trees, isomorphism, and planarity)."},
                new LearningOutcome{LearningOutcomeID=7, CourseID=1, Description="Employ formal proof techniques (such as direct proof, proof by contradiction, induction, and the pigeonhole principle) to construct sound arguments about properties of numbers, sets, functions, relations, and graphs."},

                new LearningOutcome{LearningOutcomeID=8, CourseID=2, Description="Implement, and analyze for efficiency, fundamental data structures (including lists, graphs, and trees) and algorithms (including searching, sorting, and hashing)."},
                new LearningOutcome{LearningOutcomeID=9, CourseID=2, Description="Employ Big-O notation to describe and compare the asymptotic complexity of algorithms, as well as perform empirical studies to validate hypotheses about running time."},
                new LearningOutcome{LearningOutcomeID=10, CourseID=2, Description="Recognize and describe common applications of abstract data types (including stacks, queues, priority queues, sets, and maps)."},
                new LearningOutcome{LearningOutcomeID=11, CourseID=2, Description="Apply algorithmic solutions to real-world data."},
                new LearningOutcome{LearningOutcomeID=12, CourseID=2, Description="Use generics to abstract over functions that differ only in their types."},
                new LearningOutcome{LearningOutcomeID=13, CourseID=2, Description="Appreciate the collaborative nature of computer science by discussing the benefits of pair programming."},

                new LearningOutcome{LearningOutcomeID=14, CourseID=3, Description="Design and implement large and complex software systems (including concurrent software) through the use of process models (such as waterfall and agile), libraries (both standard and custom), and modern software development tools (such as debuggers, profilers, and revision control systems)."},
                new LearningOutcome{LearningOutcomeID=15, CourseID=3, Description="Perform input validation and error handling, as well as employ advanced testing principles and tools to systematically evaluate software."},
                new LearningOutcome{LearningOutcomeID=16, CourseID=3, Description="Apply the model-view-controller pattern and event handling fundamentals to create a graphical user interface."},
                new LearningOutcome{LearningOutcomeID=17, CourseID=3, Description="Exercise the client-server model and high-level networking APIs to build a web-based software system."},
                new LearningOutcome{LearningOutcomeID=18, CourseID=3, Description="Operate a modern relational database to define relations, as well as store and retrieve data."},
                new LearningOutcome{LearningOutcomeID=19, CourseID=3, Description="Appreciate the collaborative nature of software development by discussing the benefits of peer code reviews."},

                new LearningOutcome{LearningOutcomeID=20, CourseID=4, Description="Design and implement large and complex software systems (including concurrent software) through the use of process models (such as waterfall and agile), libraries (both standard and custom), and modern software development tools (such as debuggers, profilers, and revision control systems)."},
                new LearningOutcome{LearningOutcomeID=21, CourseID=4, Description="Perform input validation and error handling, as well as employ advanced testing principles and tools to systematically evaluate software."},
                new LearningOutcome{LearningOutcomeID=22, CourseID=4, Description="Apply the model-view-controller pattern and event handling fundamentals to create a graphical user interface."},
                new LearningOutcome{LearningOutcomeID=23, CourseID=4, Description="Exercise the client-server model and high-level networking APIs to build a web-based software system."},
                new LearningOutcome{LearningOutcomeID=24, CourseID=4, Description="Operate a modern relational database to define relations, as well as store and retrieve data."},
                new LearningOutcome{LearningOutcomeID=25, CourseID=4, Description="Appreciate the collaborative nature of software development by discussing the benefits of peer code reviews."},

                new LearningOutcome{LearningOutcomeID=26, CourseID=5, Description="Explain the objectives and functions of abstraction layers in modern computing systems, including operating systems, programming languages, compilers, and applications."},
                new LearningOutcome{LearningOutcomeID=27, CourseID=5, Description="Understand cross-layer communications and how each layer of abstraction is implemented in the next layer of abstraction (such as how C programs are translated into assembly code and how C library allocators are implemented in terms of operating system memory management)."},
                new LearningOutcome{LearningOutcomeID=28, CourseID=5, Description="Analyze how the performance characteristics of one layer of abstraction affect the layers above it (such as how caching and services of the operating system affect the performance of C programs)."},
                new LearningOutcome{LearningOutcomeID=29, CourseID=5, Description="Construct applications using operating-system concepts (such as processes, threads, signals, virtual memory, I/O)."},
                new LearningOutcome{LearningOutcomeID=30, CourseID=5, Description="Synthesize operating-system and networking facilities to build concurrent, communicating applications."},
                new LearningOutcome{LearningOutcomeID=31, CourseID=5, Description="Implement reliable concurrent and parallel programs using appropriate synchronization constructs."},

                new LearningOutcome{LearningOutcomeID=32, CourseID=6, Description="Construct web pages using modern HTML and CSS practices, including modern frameworks."},
                new LearningOutcome{LearningOutcomeID=33, CourseID=6, Description="Define accessibility and utilize techniques to create accessible web pages."},
                new LearningOutcome{LearningOutcomeID=34, CourseID=6, Description="Outline and utilize MVC technologies across the “full-stack” of web design (including front-end, back-end, and databases) to create interesting web applications. Deploy an application to a “Cloud” provider."},
                new LearningOutcome{LearningOutcomeID=35, CourseID=6, Description="Describe the browser security model and HTTP; utilize techniques for data validation, secure session communication, cookies, single sign-on, and separate roles."},
                new LearningOutcome{LearningOutcomeID=36, CourseID=6, Description="Utilize JavaScript for simple page manipulations and AJAX for more complex/complete “single-page” applications."},
                new LearningOutcome{LearningOutcomeID=37, CourseID=6, Description="Demonstrate how responsive techniques can be used to construct applications that are usable at a variety of page sizes.  Define and discuss responsive, reactive, and adaptive."},
                new LearningOutcome{LearningOutcomeID=38, CourseID=6, Description="Construct a simple web-crawler for validation of page functionality and data scraping."}
            };
            foreach (LearningOutcome lom in learningOutcomes)
            {
                context.LearningOutcomes.Add(lom);
            }
            context.SaveChanges();

            // Seed some learning outcome notes
            var learningOutcomeNotes = new LearningOutcome_Note[]
            {
                new LearningOutcome_Note{LearningOutcomeID=1, Note="The students picked up on this faster than I'd expected.", LastEditByChair=false},
                new LearningOutcome_Note{LearningOutcomeID=2, Note="Hey Professor, Have you even started this one yet??", LastEditByChair=true},
            };
            foreach (LearningOutcome_Note lon in learningOutcomeNotes)
            {
                context.LearningOutcome_Notes.Add(lon);
            }
            context.SaveChanges();

            // Seed some evaluation metrics
            var evaluationMetrics = new EvaluationMetric[]
            {
                new EvaluationMetric{EvaluationMetricID=1, LearningOutcomeID=32, Name="Demonstration of HTML and CSS", Description="Students demonstrate their skills by constructing two unique HTML pages. Excellent pages should include concepts shown in lecture as well as some self-taught material.", Complete=true},
                new EvaluationMetric{EvaluationMetricID=2, LearningOutcomeID=32, Name="Quiz on CSS Theory", Description="Students are quizzed on abstract CSS concepts such as syntax, selectors, and cascading rules.", Complete=false},
            };
            foreach (EvaluationMetric ev in evaluationMetrics)
            {
                context.EvaluationMetrics.Add(ev);
            }
            context.SaveChanges();
        }
    }
}
