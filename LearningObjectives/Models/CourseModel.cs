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
        [Key]
        public int ID { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Department { get; set; }
        
        public int Year { get; set; }

        public string Semester { get; set; }

        public virtual ICollection<LearningOutcomeModel> LearningOutcomes { get; set; }
    }
}
