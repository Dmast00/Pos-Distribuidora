using POSDistribuidora.Data;
using POSDistribuidora.Domain.Interfaces;
using POSDistribuidora.Domain.Models;
using POSDistribuidora.Infrasctructure.Repository;

namespace POSDistribuidora.Infrasctructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Product> ProductRepository { get; }
        public IGenericRepository<ProductVariant> ProductVariantRepository { get; }
        public IGenericRepository<Inventory> InventoryRepository { get; }
        public IGenericRepository<Sale> SaleRepository { get; }
        public IGenericRepository<SaleDetail> SaleDetailRepository { get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ProductRepository = new GenericRepository<Product>(context);
            ProductVariantRepository = new GenericRepository<ProductVariant>(context);
            InventoryRepository = new GenericRepository<Inventory>(context);
            SaleRepository = new GenericRepository<Sale>(context);
            SaleDetailRepository = new GenericRepository<SaleDetail>(context);
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
