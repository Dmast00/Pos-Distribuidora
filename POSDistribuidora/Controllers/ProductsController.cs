using Microsoft.AspNetCore.Mvc;
using POSDistribuidora.Application.Interfaces;
using POSDistribuidora.Domain.Interfaces;
using POSDistribuidora.Domain.Models;

namespace POSDistribuidora.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductBuilder _productBuilder;
        public ProductsController(IUnitOfWork unitOfWork,IProductBuilder productBuilder)
        {
            _unitOfWork = unitOfWork;
            _productBuilder = productBuilder;
        }
        public IActionResult Index()
        {
            List<Product> product = _unitOfWork.ProductRepository.GetAll();
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product entity)
        {
            _productBuilder
                .AddProduct(entity)
                .HasProductVariant()
                .Commit();
            return View();
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _unitOfWork.ProductRepository.Get(id);
            var productVariant = _unitOfWork.ProductVariantRepository.GetAll().FirstOrDefault(x => x.ProductId == product.Id);
            product.ProductVariant = productVariant;
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product entity)
        {
            _unitOfWork.ProductRepository.Update(entity);
            _unitOfWork.Commit();

            _unitOfWork.ProductVariantRepository.Update(entity.ProductVariant);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}
