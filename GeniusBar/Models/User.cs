using Newtonsoft.Json;
using System.Collections.Generic;
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
        [JsonIgnore]
        public string Password { get; set; }

        [Required]
        public int Role_ID { get; set; }

        [ForeignKey("Role_ID")]
        public virtual Role Role { get; set; }

        [JsonIgnore]
        public ICollection<RecycleOrder> RecycleOrders { get; set; }
        
        [JsonIgnore]
        public ICollection<RepairOrder> RepairOrders { get; set; }
        
        [JsonIgnore]
        public ICollection<ServiceAddress> ServiceAddresses { get; set; }
    }
}