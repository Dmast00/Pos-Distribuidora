using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSDistribuidora.Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Sku { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Description {get; set;}

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal RetailPrice { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal WholeSalePrice { get; set; }


        [Required]
        public bool HasDiscount { get; set; }

        [Required]
        public bool HasProductVariant { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }

        [Required]
        public bool CanBeSoldByPackage { get; set; } 

        public int? UnitsPerPackage { get; set; } 


    }
}
