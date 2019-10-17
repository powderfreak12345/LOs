using EFGetStarted.AspNetCore.NewDb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearningObjectives.Models
{
    public class Course_Note
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Course_NoteID { get; set; }
        public string Note { get; set; }
        public DateTime DateStamp { get; set; }
        public bool ApprovedByChair { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}
