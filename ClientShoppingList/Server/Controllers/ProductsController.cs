﻿using ClientShoppingList.Server.Models;
using ClientShoppingList.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientShoppingList.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<Products>> GetAll()
        {
            return await _productService.GetAllProduct();
        }

        [HttpGet("{id}")]
        public async Task<Products> Get(int id)
        {
            return await _productService.GetProduct(id);
        }

        [HttpPost]
        public async Task<Products> AddProduct([FromBody] Products product)
        {
           return await _productService.AddProduct(product);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id); return true;
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateProduct(int id, [FromBody] Products Object)
        {
            await _productService.UpdateProduct(id, Object); return true;
        }


        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            // Check if the file is there
            if (file == null)
                return BadRequest("File is required");

            // Get the file name
            var fileName = file.FileName;

            // Get the extension
            var extension = Path.GetExtension(fileName);

            // Validate the extension based on your business needs

            // Generate a new file to avoid duplicates = (FileName withoutExtension - GUId.extension)
            var newFileName = $"{Path.GetFileNameWithoutExtension(fileName)}-{Guid.NewGuid().ToString()}{extension}";

            // Create the full path of the file including the directory (For this demo we will save the file inside a folder called Data within wwwroot)
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data");
            var fullPath = Path.Combine(directoryPath, newFileName);

            // Make sure the directory is there by creating it if it's not exist
            Directory.CreateDirectory(directoryPath);

            // Create a new file stream where you want to put your file and copy the content from the current file stream to the new one
            using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                // Copy the content to the new stream
                await file.CopyToAsync(fileStream);
            }

            // You are done return the new URL which is (your application url/data/newfilename)
            return Ok($"https://localhost:44302/Data/{newFileName}");
        }

    }

}