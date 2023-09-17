using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Concrete
{
    public class ShoppingList : IEntity
    {

        [Key]
        public Guid ItemsID { get; set; }
        public string ItemName { get; set; }        
        public decimal Price { get; set; }
        public string ItemImage { get; set; }
        public Guid UserID { get; set; }
        public DateTime ModifiedDate { get; set; }



    }
}
