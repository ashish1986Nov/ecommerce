using Core.Entity;
using Microsoft.EntityFrameworkCore;
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
    }
}
