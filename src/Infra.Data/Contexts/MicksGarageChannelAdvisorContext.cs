using Aarvani.ChannelAdvisor.Entities;
using System.Data.Entity;

namespace Aarvani.ChannelAdvisor.Infra.Data.Contexts
{
    public sealed class MicksGarageChannelAdvisorContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public MicksGarageChannelAdvisorContext()
            :base("Data Source = mgvm01-sql.cloudapp.net, 1433; Initial Catalog = MicksGarageChannelAdvisorDB; User ID = CopyMicksGarageDB; Password = 5tr@tu5")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
            Database.SetInitializer<MicksGarageChannelAdvisorContext>(null); //Disable Migrations
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Mappings
            modelBuilder.Configurations.Add(new Mappings.ProductsMap());
            
            base.OnModelCreating(modelBuilder); 
        }
    }
}
