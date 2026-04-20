using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }

        [Required]
        public string ItemName { get; set; }
        public string Size { get; set; }
        public decimal  Price { get; set; }
    }
}