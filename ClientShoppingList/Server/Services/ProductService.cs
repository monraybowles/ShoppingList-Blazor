using ClientShoppingList.Server.Models;
using ClientShoppingList.Server.Repository;

namespace ClientShoppingList.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Products> _product;
        public ProductService(IRepository<Products> product)
        {
            _product = product;
        }
        public async Task<Products> AddProduct(Products product)
        {
            return await _product.CreateAsync(product);
        }

        public async Task<bool> UpdateProduct(int id, Products product) 
        {
            var data = await _product.GetByIdAsync(id);

            if (data != null)
            {  

                data.ProductName = product.ProductName;
                data.Description = product.Description;
                data.Price = product.Price;
                data.Img = product.Img;
                await _product.UpdateAsync(data);
                return true;

            }
            else

                return false;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            await _product.DeleteAsync(id);
            return true;
        }


        public async Task<List<Products>> GetAllProduct()
        {
            return await _product.GetAllAsync();
        }

        public async Task<Products> GetProduct(int id)
        {
           return await _product.GetByIdAsync(id);
        }
    }
}
