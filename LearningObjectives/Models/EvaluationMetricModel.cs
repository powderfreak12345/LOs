﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EFGetStarted.AspNetCore.NewDb.Models;
using System.Linq;
using System.Threading.Tasks;

namespace LearningObjectives.Models
{
    public class EvaluationMetricModel
    {
        public EvaluationMetricModel()
        {

        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EvaluationMetricModelID { get; set; }

        // The name for an evaluation metric
        public string Name { get; set; }
        
        // A description of the evaluation metric
        public string Description { get; set; }

        // Used to determine if the evaluation metric is completed or not.
        public bool Complete { get; set; }

        public LearningOutcomeModel LearningOutcome { get; set; }

        // The foreign key linking this evaluation metric to specific learning outcome
        public int LearningOutcomeModelID { get; set; }

    }
}
