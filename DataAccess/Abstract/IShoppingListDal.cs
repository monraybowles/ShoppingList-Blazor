using Core.DataAccess.Abstract;
using Core.Entities.Concrete;


namespace DataAccess.Abstract
{
    public interface IShoppingListDal : IEntityRepository<ShoppingList>
    {
        List<ShoppingList> GetShoppingListDetails();

        List<ShoppingList> GetShoppingList();
        List<ShoppingList> GetShoppingListByShoppingListId(Guid id);
    }}

