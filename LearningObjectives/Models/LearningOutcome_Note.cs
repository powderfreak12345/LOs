using EFGetStarted.AspNetCore.NewDb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearningObjectives.Models
{
    public class LearningOutcome_Note
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LearningOutcome_NoteID { get; set; }
        public string Note { get; set; }
        public bool LastEditByChair { get; set; }

        public int LearningOutcomeID { get; set; }
        public LearningOutcome LearningOutcome { get; set; }
    }

}
