using POSDistribuidora.Domain.Models;

namespace POSDistribuidora.Application.Interfaces
{
    public interface IInventoryBuilder
    {
        IInventoryBuilder GetProductFromId(int productId);
        IInventoryBuilder GetAllInventory();

        IInventoryBuilder IfProductExistOnInventory(int stockQuantity);

        void Commit();
    }
}
