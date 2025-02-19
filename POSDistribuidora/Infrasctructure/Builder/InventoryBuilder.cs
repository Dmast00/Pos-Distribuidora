using POSDistribuidora.Application.Interfaces;
using POSDistribuidora.Domain.Interfaces;
using POSDistribuidora.Domain.Models;

namespace POSDistribuidora.Infrasctructure.Builder
{
    public class InventoryBuilder : IInventoryBuilder
    {
        private readonly IUnitOfWork _unitOfWork;
        private Product _product;
        private List<Inventory> _inventoryList;
        private Inventory _inventory;
        private Product _productExist;
        public InventoryBuilder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IInventoryBuilder GetProductFromId(int productId)
        {
            _product = _unitOfWork.ProductRepository.Get(productId);
            return this;
        }

        public IInventoryBuilder GetAllInventory()
        {
            _inventoryList = _unitOfWork.InventoryRepository.GetAll();
            return this;
        }


        public IInventoryBuilder IfProductExistOnInventory(int stockQuantity)
        {
            _inventory = _inventoryList.FirstOrDefault(x => x.ProductId == _product.Id);
            if(_inventory == null)
            {
                _inventory = new Inventory
                {
                    Product = _product,
                    ProductId = _product.Id,
                    StockQuantity = stockQuantity,
                    LastUpdate = DateTime.Now,
                };
                _unitOfWork.InventoryRepository.Add(_inventory);
            }
            else
            {

                _inventory.StockQuantity += stockQuantity;
                _inventory.LastUpdate = DateTime.Now;
                _unitOfWork.InventoryRepository.Update(_inventory);
            }
            
            return this;
        }

        public void Commit() => _unitOfWork.Commit();   
    }
}
