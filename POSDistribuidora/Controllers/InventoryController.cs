using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using POSDistribuidora.Application.Interfaces;
using POSDistribuidora.Domain.Interfaces;
using POSDistribuidora.Domain.Models;

namespace POSDistribuidora.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInventoryBuilder _inventoryBuilder;
        public InventoryController(IUnitOfWork unitOfWork,IInventoryBuilder inventoryBuilder)
        {
            _unitOfWork = unitOfWork;
            _inventoryBuilder = inventoryBuilder;
        }
        public IActionResult Index()
        {
            var product = _unitOfWork.ProductRepository.GetAll();
            var inventory =  _unitOfWork.InventoryRepository.GetAll();
            foreach(var item in inventory)
            {
                Product productObject = new Product();
                productObject = product.Where(x => x.Id == item.ProductId).ToList().FirstOrDefault();
                item.Product = productObject;
                
            }
            return View(inventory);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Products = _unitOfWork.ProductRepository.GetAll();
            
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Inventory inventory)
        {

            _inventoryBuilder
                .GetProductFromId(inventory.ProductId)
                .GetAllInventory()
                .IfProductExistOnInventory(inventory.StockQuantity)
                .Commit();
            return RedirectToAction("Index");
        }
    }
}
