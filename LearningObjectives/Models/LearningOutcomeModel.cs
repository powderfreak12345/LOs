using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LearningObjectives.Models;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    
    public class LearningOutcomeModel
    {
        // The primary key
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LearningOutcomeModelID { get; set; }

        // The foreign key to the course model
        public int CourseModelID { get; set; }

        // The LO's name
        public string Name { get; set; }

        // A description of the LO
        public string Description { get; set; }
        
        // The course that the LO belongs to
        public CourseModel Course { get; set; }

        // A course has a one-to-many relationship with LearningOutcomes
        public virtual ICollection<EvaluationMetricModel> EvaluationMetrics { get; set; }
    }
}
