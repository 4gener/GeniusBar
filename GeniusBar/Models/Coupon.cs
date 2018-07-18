using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeniusBar.Models
{
    public enum CouponType
    {
        DISCOUNT,
        REDUCTION
    }

    public class Coupon
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public CouponType Type { get; set; }

        [Required]
        [DataType("decimal(5,2)")]
        public decimal Discount { get; set; }

        [Required]
        public byte State { get; set; }

        public ICollection<RepairOrder> RepairOrders { get; set; }
    }
}