using POSDistribuidora.Domain.Interfaces;
using POSDistribuidora.Domain.Models;

namespace POSDistribuidora.Application.Interfaces
{
    public interface IProductBuilder
    {
        IProductBuilder AddProduct(Product product);
        IProductBuilder HasProductVariant();

        void Commit();
    }
}
