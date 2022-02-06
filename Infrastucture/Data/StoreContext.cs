using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
//using Core.Entity;
namespace Infrastucture.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }


        //protected override OnModelCreating(DbModelBuilder dbModelBuilder)
        //{
        //    dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    dbModelBuilder.Conventions.Remove<IncludeMetadataConvention>();
        //}



        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (String.Compare(Database.ProviderName, "Microsoft.EntityFrameworkCore.Sqlite", true) == 0)
            {
                foreach (var entityType in modelbuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties()
                        .Where(p => p.PropertyType == typeof(decimal));

                    foreach (var property in properties)
                    {
                        modelbuilder.Entity(entityType.Name).Property(property.Name)
                            .HasConversion<double>();

                    }


                }
            }



        }
    }
}
