using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeniusBar.Models
{
    public class LaptopModel
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType("decimal(7,2)")]
        public decimal Rec_base_value { get; set; }

        [Required]
        [MaxLength(100)]
        public string TIMG_url { get; set; }


        [ForeignKey("LaptopBrand")]
        [Required]
        public int Brand_ID { get; set; }
        public LaptopBrand LaptopBrand { get; set; }

        public ICollection<RecycleEvaluationCategory> RecycleEvaluationCategories { get; set; }

        public ICollection<RepairChoice> RepairChoices { get; set; }

    }
}