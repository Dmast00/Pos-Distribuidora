using Microsoft.AspNetCore.Mvc;
using POSDistribuidora.Application.Interfaces;
using POSDistribuidora.Domain.Interfaces;
using POSDistribuidora.Domain.Models;
using POSDistribuidora.Domain.Models.ViewModels;
using POSDistribuidora.Infrasctructure.Builder;

namespace POSDistribuidora.Controllers
{
    public class SalesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISaleBuilder _saleBuilder;
       
        public SalesController(IUnitOfWork unitOfWork, ISaleBuilder saleBuilder)
        {
            _unitOfWork = unitOfWork;
            _saleBuilder = saleBuilder;
        }
        public IActionResult Index()
        {
            ViewBag.Products = _unitOfWork.ProductRepository.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult CreateSale(SaleDetailsViewmodel saleDetails)
        {
            _saleBuilder
                 .GetProductsObjectList(saleDetails.ProductsId)
                 .CalculateTotalAmount()
                 .CreateSale()
                 .CreateSaleDetails()
                 .UpdateProductInventory();

            return RedirectToAction("Index");
        }
    }
}
