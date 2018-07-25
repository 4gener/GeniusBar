using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace GeniusBar.Models
{
    public enum RepairOrderState
    {
        REPAIRING,
        REPAIRED,
        DELIVERING
    }

    public class RepairOrder
    {
        public int ID { get; set; }

        [Required]
        public DateTime Create_time { get; set; }

        [Required]
        public DateTime Service_time { get; set; }

        [MaxLength(300)]
        public string Customer_note { get; set; }

        [MaxLength(300)]
        public string Staff_note { get; set; }

        [Required]
        [DataType("decimal(6,2)")]
        public decimal Price { get; set; }

        [Required]
        public RepairOrderState State { get; set; }

        [Required]
        [MaxLength(200)]
        public string Loc_name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Loc_detail { get; set; }

        [Required]
        public int Customer_ID { get; set; }

        public int? Coupon_ID { get; set; }

        public int? Engineer_ID { get; set; }

        [ForeignKey("Customer_ID ")]
        public User User { get; set; }

        [ForeignKey("Coupon_ID ")]
        public Coupon Coupon { get; set; }

        [ForeignKey("Engineer_ID ")]
        public User Users { get; set; }
        
        [JsonIgnore]
        public ICollection<RepairOrder_RepairChoice> RepairOrder_RepairChoices { get; set; }
    }
}