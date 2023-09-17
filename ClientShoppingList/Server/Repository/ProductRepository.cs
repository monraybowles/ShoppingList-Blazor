using ClientShoppingList.Server.Data;
using ClientShoppingList.Server.Models;
using ClientShoppingList.Server.Repository;
using Microsoft.EntityFrameworkCore;

namespace ClientShoppingList.Server.Repository
{
    public class ProductRepository : IRepository<Products>
    {
        ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Products> CreateAsync(Products _object)
        {
            var obj = await _dbContext.Products.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public async Task UpdateAsync(Products _object)
        {
            _dbContext.Products.Update(_object);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Products>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Products> GetByIdAsync(int Id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task DeleteAsync(int id)
        {
            var data = _dbContext.Products.FirstOrDefault(x=>x.Id == id);
            _dbContext.Remove(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}
