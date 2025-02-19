using POSDistribuidora.Application.Interfaces;
using POSDistribuidora.Domain.Interfaces;
using POSDistribuidora.Domain.Models;
using POSDistribuidora.Domain.Models.ViewModels;
using System.Linq;
namespace POSDistribuidora.Infrasctructure.Builder
{
    public class SaleBuilder : ISaleBuilder
    {
        private readonly IUnitOfWork _unitOfWork;
        private decimal _totalAmount;
        private List<Product> _products;
        private Sale _sale;
        private SaleDetail _saleDetail;
        public SaleBuilder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           
        }
        public ISaleBuilder GetProductsObjectList(List<int> productsId)
        {
            if(productsId == null || productsId.Count == 0)
            {
                return this;
            }
            _products = productsId.Select(x => _unitOfWork.ProductRepository.Get(x)).ToList();

            return this;
        }
        public ISaleBuilder CalculateTotalAmount()
        {
            _totalAmount = _products.Sum(x => x.RetailPrice);
            return this;
        }

        public ISaleBuilder CreateSale()
        {
            _sale = new Sale
            {
               TotalAmount = _totalAmount
            };
            _unitOfWork.SaleRepository.Add(_sale);
            _unitOfWork.Commit();   
            return this;
        }

        public ISaleBuilder CreateSaleDetails()
        {
            foreach(var item in _products)
            {
                var saleId = _sale.Id;
                var productId = item.Id;
                var productsVariants = _unitOfWork.ProductVariantRepository.GetAll();
                var productVariant = productsVariants.FirstOrDefault(x => x.ProductId == productId);
                _saleDetail = new SaleDetail
                {
                    SaleId = saleId,
                    ProductId = productId,
                    Quantity = 1,
                    Price = item.RetailPrice,
                    SubTotal = item.RetailPrice,
                    ProductVariant = productVariant,
                };

            _unitOfWork.SaleDetailRepository.Add(_saleDetail);
            _unitOfWork.Commit();
            }

            return this;
        }

        public ISaleBuilder UpdateProductInventory()
        {
            
            foreach (var item in _products)
            {
                var inventory = _unitOfWork.InventoryRepository.Get(item.Id);

                inventory.StockQuantity -= 1;
                inventory.LastUpdate = inventory.LastUpdate;
                inventory.LastSale = DateTime.Now;

                _unitOfWork.InventoryRepository.Update(inventory);
            }
            _unitOfWork.Commit();
            return this;
        }
    }
}
