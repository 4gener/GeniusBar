using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeniusBar.Models
{
    public class RecycleEvaluationCategory
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string TIMG_url { get; set; }


        [MaxLength(200)]
        public string Description { get; set; }

        [ForeignKey("LaptopModel")]
        [Required]
        public int Model_ID { get; set; }
        public LaptopModel LaptopModel { get; set; }

        public ICollection<RecycleEvaluationChoice> RecycleEvaluationChoices { get; set; }
    }
}