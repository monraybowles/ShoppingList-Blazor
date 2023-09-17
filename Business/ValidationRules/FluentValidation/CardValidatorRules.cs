using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.ValidationRules.FluentValidation
{ 
    //public class ShoppingListRules : IShoppingListService
    //{  
       
    //    public IResult Add(CreditCardValidation CreditCardValidation)
    //    {
    //        int sum = 0;
    //        bool isAlternate = false;
    //        for (int i = CreditCardValidation.CardNumber.Length - 1; i >= 0; i--)
    //        {
    //            int digit = int.Parse(CreditCardValidation.CardNumber[i].ToString());
    //            if (isAlternate)
    //            {
    //                digit *= 2;
    //                if (digit > 9)
    //                {
    //                    digit = (digit % 10) + 1;
    //                }
    //            }
    //            sum += digit;
    //            isAlternate = !isAlternate;
    //        }
    //        var x = (sum % 10) == 0;

    //        return new SuccessResult(Messages.Added);
    //    }

    //    public IResult Delete(CreditCardValidation CreditCardValidation)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IDataResult<List<CreditCardValidation>> GetAll()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IDataResult<CreditCardValidation> GetById(Guid id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IDataResult<List<CreditCardValidation>> GetCreditCardValidationDetails()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IResult Update(CreditCardValidation CreditCardValidation)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
