using Core.Entities.Concrete;
using Core.Utilities.Results;


namespace Business.Abstract
{
    public interface IShoppingListService
    {


        IDataResult<List<ShoppingList>> GetAll();
        IDataResult<List<ShoppingList>> GetShoppingListDetails();
      
        IDataResult<ShoppingList> GetById(Guid id);
        IResult Add(ShoppingList ShoppingList);
        IResult Delete(ShoppingList ShoppingList);
        IResult Update(ShoppingList ShoppingList);


    }
}
