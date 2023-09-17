using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        IShoppingListService _ShoppingListService;

        public ShoppingListController(IShoppingListService ShoppingListService)
        {
            _ShoppingListService = ShoppingListService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _ShoppingListService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(Guid id)
        {
            var result = _ShoppingListService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(ShoppingList ShoppingList)
        {
            var result = _ShoppingListService.Add(ShoppingList);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(ShoppingList ShoppingList)
        {

            var result = _ShoppingListService.Delete(ShoppingList);
            return result.Success ? Ok(result) : BadRequest(result);

        }

        [HttpPut("update")]
        public IActionResult Update(ShoppingList ShoppingList)
        {

            var result = _ShoppingListService.Update(ShoppingList);
            return result.Success ? Ok(result) : BadRequest(result);

        }
    }
}
