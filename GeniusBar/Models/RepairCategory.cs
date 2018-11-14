using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace GeniusBar.Models
{
    public class RepairCategory
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

        [JsonIgnore]
        public ICollection<RepairChoice> RepairChoices { get; set; }
    }
}