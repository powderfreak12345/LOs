using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    
    public class LearningOutcome
    {
        // The primary key
        public int LearningOutcomeID { get; set; }

        // The foreign key to the course model
        public int CourseID { get; set; }

        // The LO's name
        public string Name { get; set; }

        // A description of the LO
        public string Description { get; set; }
        
        // The course that the LO belongs to
        public Course Course { get; set; }
    }
}
