using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeniusBar.Models
{
    public class RepairChoice
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType("decimal(6,2)")]
        public decimal Price { get; set; }

        [Required]
        public int Category_ID { get; set; }

        [Required]
        public int Model_ID { get; set; }

        [ForeignKey("Category_ID")]
        public RepairCategory RepairCategory { get; set; }

        [ForeignKey("Model_ID")]
        public LaptopModel LaptopModel { get; set; }

        public ICollection<RepairOrder_RepairChoice> RepairOrder_RepairChoices { get; set; }

    }
}