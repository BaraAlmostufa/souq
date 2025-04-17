using System.ComponentModel.DataAnnotations.Schema;

namespace souq6.Models
{
    public class Cart
    {

        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string? UserID { get; set; }

        [ForeignKey("product")]
        public int ProductID { get; set; }
        public string   Product { get; set; }



    }
}
