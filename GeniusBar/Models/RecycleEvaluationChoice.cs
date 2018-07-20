using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeniusBar.Models
{
    public class RecycleEvaluationChoice
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType("decimal(6,2)")]
        public decimal Discreet_value { get; set; }

        [ForeignKey("RecycleEvaluationCategory")]
        [Required]
        public int Category_ID { get; set; }
        public RecycleEvaluationCategory RecycleEvaluationCategory { get; set; }

        public ICollection<RecycleOrder_RecycleEvaluatonChoice> RecycleOrder_RecycleEvaluatonChoices { get; set; }
    }
}