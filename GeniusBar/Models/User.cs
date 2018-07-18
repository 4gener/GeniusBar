using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeniusBar.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(60)]
        public string Password { get; set; }

        [Required]
        public int Role_ID { get; set; }

        [ForeignKey("Role_ID ")]
        public Role Role { get; set; }

        public ICollection<RecycleOrder> RecycleOrders { get; set; }
        public ICollection<RepairOrder> RepairOrders { get; set; }
        public ICollection<ServiceAddress> ServiceAddresses { get; set; }
    }
}