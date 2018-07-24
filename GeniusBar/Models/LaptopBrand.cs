using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GeniusBar.Models
{
    public class LaptopBrand
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string TIMG_url { get; set; }

        [JsonIgnore]
        public ICollection<LaptopModel> LaptopModels { get; set; }
    }
}