using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSDistribuidora.Domain.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        
        [ForeignKey("Id")]
        public virtual Product Product { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public DateTime? LastSale { get; set; }
    }
}
