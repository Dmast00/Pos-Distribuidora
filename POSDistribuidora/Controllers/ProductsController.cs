using Microsoft.AspNetCore.Mvc;
using POSDistribuidora.Domain.Interfaces;
using POSDistribuidora.Domain.Models;

namespace POSDistribuidora.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product entity)
        {
            _unitOfWork.ProductRepository.Add(entity);
            _unitOfWork.Commit();
            return View();
        }
    }
}
