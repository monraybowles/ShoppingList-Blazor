using Core.DataAccess.Concrete;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfShoppingListDal : EfEntityRepositoryBase<ShoppingList, ApplicationDbContext>, IShoppingListDal
    {
        public List<ShoppingList> GetAll()
        {
            using (var context = new ApplicationDbContext())
            {
                var result = from ShoppingList in context.ShopItems
                             
                             select new ShoppingList { ItemsID = ShoppingList.ItemsID, ModifiedDate= ShoppingList.ModifiedDate };

                return result.ToList();

            }
        }

        public List<ShoppingList> GetShoppingList(ShoppingList user)
        {
            using (var context = new ApplicationDbContext())
            {
                var result = from ShoppingList in context.ShopItems
                             where ShoppingList.ItemsID == user.ItemsID
                             select new ShoppingList { ItemsID = ShoppingList.ItemsID, ModifiedDate = ShoppingList.ModifiedDate };

                return result.ToList();

            }
        }

        public List<ShoppingList> GetCreditCardValidationByCreditCardValidationId(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ShoppingList> GetCreditCardValidationD()
        {
            throw new NotImplementedException();
        }

        public List<ShoppingList> GetCreditCardValidationDetails()
        {
            throw new NotImplementedException();
        }

        public List<ShoppingList> GetShoppingListDetails()
        {
            throw new NotImplementedException();
        }

        public List<ShoppingList> GetShoppingList()
        {
            throw new NotImplementedException();
        }

        public List<ShoppingList> GetShoppingListByShoppingListId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
