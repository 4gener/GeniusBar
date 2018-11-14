using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeniusBar.Models
{
    public class WebBanner
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Image { get; set; }

        [Required]
        public bool If_show { get; set; }

    }
}