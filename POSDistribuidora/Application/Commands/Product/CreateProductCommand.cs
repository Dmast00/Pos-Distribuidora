using MediatR;
using POSDistribuidora.Domain.Interfaces;
using POSDistribuidora.Domain.Models;

namespace POSDistribuidora.Application.Commands.Product
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Sku { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public decimal RetailPrice { get; set; }

        public decimal WholeSalePrice { get; set; }
        public bool HasDiscount { get; set; }
        public bool HasProductVariant { get; set; }
        public bool CanBeSoldByPackage { get; set; }
        public int UnitsPerPackage { get; set; }
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateProductCommand request,CancellationToken cancellationToken)
        {
            var product = new Domain.Models.Product
            {
                Sku = request.Sku,
                Name = request.Name,
                Description = request.Description,
                RetailPrice = request.RetailPrice,
                WholeSalePrice = request.WholeSalePrice,
                HasDiscount = request.HasDiscount,
                HasProductVariant = request.HasProductVariant,
                CanBeSoldByPackage = request.CanBeSoldByPackage,
                UnitsPerPackage = request.UnitsPerPackage
            };
            _unitOfWork.ProductRepository.Add(product);
            _unitOfWork.Commit();
            return product.Id;
        }
    }
}
