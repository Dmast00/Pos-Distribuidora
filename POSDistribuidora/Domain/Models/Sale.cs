using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSDistribuidora.Domain.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime SaleDate { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalAmount { get; set; }

        public virtual List<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    }
}
