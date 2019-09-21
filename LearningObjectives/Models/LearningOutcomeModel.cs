using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    
    public class LearningOutcomeModel
    {
        // The primary key
        public int LearningOutcomeModelID { get; set; }

        // The foreign key to the course model
        public int CourseModelID { get; set; }

        // The LO's name
        public string Name { get; set; }

        // A description of the LO
        public string Description { get; set; }
        
        // The course that the LO belongs to
        public CourseModel Course { get; set; }
    }
}
