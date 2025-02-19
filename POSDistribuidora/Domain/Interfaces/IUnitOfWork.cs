using POSDistribuidora.Domain.Models;

namespace POSDistribuidora.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Product> ProductRepository { get; }
        public IGenericRepository<ProductVariant> ProductVariantRepository { get; }
        public IGenericRepository<Inventory> InventoryRepository { get; }
        public IGenericRepository<Sale> SaleRepository { get; }
        public IGenericRepository<SaleDetail> SaleDetailRepository { get; }

        void Commit();

    }
}
