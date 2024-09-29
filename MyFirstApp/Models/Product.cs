using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstApp.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "A termék ára nem lehet negatív!")]
        public decimal Price { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
    }
}
