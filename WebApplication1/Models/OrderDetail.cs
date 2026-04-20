using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2.Models
{
    public class OrderDetail
    {
        [Key]
        public int ID { get; set; }
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }
        public int ItemID { get; set; }
        [ForeignKey("ItemID")]
        public virtual Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal UnitAmount { get; set; }
    }
}