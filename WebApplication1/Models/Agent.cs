using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Agent
    {
        [Key]
        public int AgentID { get; set; }
        [Required]
        [StringLength(150)]
        public string AgentName { get; set; }

        public string Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
