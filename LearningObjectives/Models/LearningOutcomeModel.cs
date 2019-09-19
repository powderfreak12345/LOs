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
        public int ID { get; set; }

        // The LO's name
        public string Name { get; set; }

        // A description of the LO
        public string Description { get; set; }

        // The CourseInstanceID connects a Learning Outcome to the course it belongs to.
        // This int is the same as the primary key for the course.
        public int CourseInstanceID { get; set; }  
    }
}
