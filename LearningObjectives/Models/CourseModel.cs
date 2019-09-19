using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LearningObjectives.Models;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class CourseModel
    {
        // The primary key for identifying each unique course.
        public int ID { get; set; }

        // The course number.  Ex.  3500, 3505, 4540
        public int Number { get; set; }

        // The course name. Ex. 'Software Practice I', 'Web Software Architecture'
        public string Name { get; set; }

        // A brief description of the course
        public string Description { get; set; }

        // The department overseeing the course
        public string Department { get; set; }
        
        // The year the course is being taught
        public int Year { get; set; }

        // The semester the course is being taught.  Ex: 'Spring', 'Summer', 'Fall'
        public string Semester { get; set; }

        // A course has a one-to-many relationship with LearningOutcomes
        public virtual ICollection<LearningOutcomeModel> LearningOutcomes { get; set; }
    }
}
