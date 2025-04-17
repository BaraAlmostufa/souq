using System.ComponentModel.DataAnnotations.Schema;

namespace souq6.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string? Name  { get; set; }
        public  string? Description { get; set; }

        [NotMapped]
        public IFormFile?  Imagefile{ get; set; }

        public string? Image { get; set; }

        public float? Price { get; set; }

        public DateTime? Date { get; set; }

        [ForeignKey("category")]
        public int CategoryID { get; set; }
        public Category? category { get; set; }

        List<Cart>?  carts { get; set; }


}
}
