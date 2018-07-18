using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GeniusBar.Models
{
    public class Role_Authorization
    {
        [Key]
        [Column(Order = 1)]
        [Required]
        public int Role_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        public int Auth_ID { get; set; }

        [ForeignKey("Role_ID")]
        public Role Role { get; set; }

        [ForeignKey("Auth_ID")]
        public Authorization Authorization { get; set; }
    }
}