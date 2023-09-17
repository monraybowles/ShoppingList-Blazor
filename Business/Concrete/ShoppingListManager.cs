using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class ShoppingListManager : IShoppingListService
    {
        IShoppingListDal _ShoppingListDal;
        public ShoppingListManager(IShoppingListDal ShoppingListDal)
        {
            _ShoppingListDal = ShoppingListDal;
        }

        

        public IResult Add(ShoppingList ShoppingList)
        {

            //    return new ErrorResult(Messages.UserNameInvalid);


            _ShoppingListDal.Add(ShoppingList);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(ShoppingList ShoppingList)
        {
            _ShoppingListDal.Delete(ShoppingList);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<ShoppingList>> GetAll()
        {
            return new SuccessDataResult<List<ShoppingList>>(_ShoppingListDal.GetAll());
        }

        public IDataResult<ShoppingList> GetById(Guid id)
        {
            return new SuccessDataResult<ShoppingList>(_ShoppingListDal.Get(p => p.ItemsID == id));
        }

        public IDataResult<List<ShoppingList>> GetCreditCardValidationDetails()
        {
            throw new NotImplementedException();
        }

     
        public IDataResult<List<ShoppingList>> GetShoppingListDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Update(ShoppingList ShoppingList)
        {
            throw new NotImplementedException();
        }
    }
}
