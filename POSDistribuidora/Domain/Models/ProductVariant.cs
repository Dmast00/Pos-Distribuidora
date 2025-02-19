using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSDistribuidora.Domain.Models
{
    public class ProductVariant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; } // Clave foránea correcta sin doble anotación

        [Required]
        public string UnitOfMeasure { get; set; }

        [Required]
        public int ConversionFactor { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        // 🔹 Aquí es donde definimos la clave foránea correctamente
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
    }
}
