using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeniusBar.Models
{
    public class RepairOrder_RepairChoice
    {
        [Key]
        [Column(Order = 1)]
        [Required]
        public int Rep_order_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        public int Rep_choice_ID { get; set; }

        [ForeignKey("Rep_order_ID")]
        public RepairOrder RepairOrder { get; set; }

        [ForeignKey("Rep_choice_ID")]
        public RepairChoice RepairChoice { get; set; }
    }
}