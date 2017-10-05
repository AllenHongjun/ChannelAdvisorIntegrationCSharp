using Aarvani.ChannelAdvisor.Entities;
using System.Collections.Generic;

namespace Aarvani.ChannelAdvisor.Contracts
{
    public interface IProductsRepository
    {
        void AddProduct(Product product);

        void AddProducts(List<Product> products);
    }
}
