using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public int AgentID { get; set; }
        [ForeignKey("AgentID")]
        public virtual Agent Agent { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}