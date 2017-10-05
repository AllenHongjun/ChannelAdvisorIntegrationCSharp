
using Aarvani.ChannelAdvisor.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Aarvani.ChannelAdvisor.Infra.Data.Mappings
{
    public sealed class ProductsMap : EntityTypeConfiguration<Product>
    {
        public ProductsMap()
        {
            ToTable("Products");

            HasKey(x => x.ChannelProductID);
        }
    }
}
