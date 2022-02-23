using Microsoft.EntityFrameworkCore;
using WebApp.Strategy.Models;

namespace WebApp.Strategy.Repositories
{
    public class ProductRepositoryFromSqlServer : IProductRepository
    {
        private readonly AppIdentityDbContext _appIdentityDbContext;

        public ProductRepositoryFromSqlServer(AppIdentityDbContext appIdentityDbContext)
        {
            _appIdentityDbContext = appIdentityDbContext;
        }

        public async Task Delete(Product product)
        {
            // 1 => _appIdentityDbContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            // 2 => _appIdentityDbContext.Remove(product);

            _appIdentityDbContext.Remove(product);

            await _appIdentityDbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllByUserId(string userId)
        {
            return await _appIdentityDbContext.Products.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Product> GetById(string id)
        {
            // 1 => return await _appIdentityDbContext.Products.FindAsync(id);
            // 2 => return await _appIdentityDbContext.FindAsync<Product>(id);

            return await _appIdentityDbContext.Products.FindAsync(id);
        }

        public async Task<Product> Save(Product product)
        {
            product.Id = Guid.NewGuid().ToString();

            await _appIdentityDbContext.Products.AddAsync(product);

            await _appIdentityDbContext.SaveChangesAsync();

            return product;
        }

        public async Task Update(Product product)
        {
            _appIdentityDbContext.Products.Update(product);

            await _appIdentityDbContext.SaveChangesAsync();
        }
    }
}
