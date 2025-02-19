using POSDistribuidora.Application.Interfaces;
using POSDistribuidora.Domain.Interfaces;
using POSDistribuidora.Domain.Models;

namespace POSDistribuidora.Infrasctructure.Builder
{
    public class ProductBuilder : IProductBuilder
    {
        private readonly IUnitOfWork _unitOfWork;
        private Product _product;
        private ProductVariant _productVariant;
        public ProductBuilder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IProductBuilder AddProduct(Product product)
        {
            _product = product;
            _unitOfWork.ProductRepository.Add(_product);
            _unitOfWork.Commit();
            return this;
        }
        public IProductBuilder HasProductVariant()
        {
            if(_product.HasProductVariant == true)
            {
                _productVariant = new ProductVariant
                {
                    ProductId = _product.Id,    
                    Product = _product,
                    UnitOfMeasure = _product.ProductVariant.UnitOfMeasure,
                    ConversionFactor = _product.ProductVariant.ConversionFactor,
                    Price = _product.ProductVariant.Price,
                };
                _unitOfWork.ProductVariantRepository.Add(_productVariant);
            }
            return this;
        }

        public void Commit() => _unitOfWork.Commit();

    }
}
