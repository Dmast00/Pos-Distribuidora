using POSDistribuidora.Domain.Models;
using POSDistribuidora.Domain.Models.ViewModels;

namespace POSDistribuidora.Application.Interfaces
{
    public interface ISaleBuilder
    {
        ISaleBuilder GetProductsObjectList(List<int> productsId);

        ISaleBuilder CalculateTotalAmount();

        ISaleBuilder CreateSale();

        ISaleBuilder CreateSaleDetails();

        ISaleBuilder UpdateProductInventory();
    }
}
