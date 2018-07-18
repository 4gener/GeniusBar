using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeniusBar.Models
{
    public class ServiceAddress
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Loc_name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Loc_detail { get; set; }

        [Required]
        public int Customer_ID { get; set; }

        [ForeignKey("Customer_ID ")]
        public User User { get; set; }
    }
}