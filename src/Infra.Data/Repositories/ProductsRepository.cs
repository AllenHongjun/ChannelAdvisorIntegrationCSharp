using Aarvani.ChannelAdvisor.Contracts;
using Aarvani.ChannelAdvisor.Entities;
using System.Collections.Generic;

namespace Aarvani.ChannelAdvisor.Infra.Data.Repositories
{
    public sealed class ProductsRepository : IProductsRepository
    {
        Contexts.MicksGarageChannelAdvisorContext context;

        public ProductsRepository()
        {

        }
        
        public void AddProduct( Product product) {
            using (context = new Contexts.MicksGarageChannelAdvisorContext()) {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void AddProducts(List<Product> products)
        {
            using (context = new Contexts.MicksGarageChannelAdvisorContext())
            {
                context.Products.AddRange(products);
                context.SaveChanges();
            }

        }

    }
}
