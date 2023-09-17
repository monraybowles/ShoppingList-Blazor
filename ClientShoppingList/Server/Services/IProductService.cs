using ClientShoppingList.Server.Models;

namespace ClientShoppingList.Server.Services
{
    public interface IProductService
    {
        Task<Products> AddProduct(Products product);

        Task<bool> UpdateProduct(int id, Products product);

        Task<bool> DeleteProduct(int id);

        Task<List<Products>> GetAllProduct();

        Task<Products> GetProduct(int id);

    }
}
