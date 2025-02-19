using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSDistribuidora.Domain.Models
{
    public class ProductVariant
    {
        [Key]   
        public int Id { get; set; }
        
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string UnitOfMeasure { get; set; }

        [Required]
        public int ConversionFactor { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [ForeignKey("Id")]
        [Required]
        public virtual Product Product { get; set; }
    }
}
