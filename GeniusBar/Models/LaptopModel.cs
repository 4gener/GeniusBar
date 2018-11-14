using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

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
        public virtual LaptopBrand LaptopBrand { get; set; }

        [JsonIgnore]
        public ICollection<RecycleEvaluationCategory> RecycleEvaluationCategories { get; set; }

        [JsonIgnore]
        public ICollection<RepairChoice> RepairChoices { get; set; }

    }
}