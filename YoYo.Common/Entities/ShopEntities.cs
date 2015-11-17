using System.Data.Entity;

namespace YoYo.Common.Entities
{
    public class ShopEntities : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }

        static ShopEntities()
        {
            Database.SetInitializer<ShopEntities>(new CreateDatabaseIfNotExists<ShopEntities>());
        }
    }
}