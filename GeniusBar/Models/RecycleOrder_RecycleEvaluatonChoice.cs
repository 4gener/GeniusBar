using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeniusBar.Models
{
    public class RecycleOrder_RecycleEvaluatonChoice
    {
        [Key]
        [Column(Order = 1)]
        [Required]
        public int Rec_order_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        public int Rec_eval_choice_ID { get; set; }

        [ForeignKey("Rec_order_ID")]
        public RecycleOrder RecycleOrder { get; set; }

        [ForeignKey("Rec_eval_choice_ID")]
        public RecycleEvaluationChoice RecycleEvaluationChoice { get; set; }

    }
}