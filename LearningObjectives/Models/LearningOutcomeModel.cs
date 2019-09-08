using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    
    public class LearningOutcomeModel
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // The CourseInstanceID connects a Learning Outcome to the course it belongs to.
        public int CourseInstanceID { get; set; }  
    }
}
