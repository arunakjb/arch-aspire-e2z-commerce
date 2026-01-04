using E2Z.DB.ORM.Context;
using E2Z.DB.ORM.Models;
using E2Z.DB.ORM.Repositories.Interfaces;

namespace E2Z.DB.ORM.Repositories
{
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(E2ZDbContext context) : base(context) { }
        // Add custom methods if needed
    }
}