using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DTOs
{
    public class ShoppingListDto : IDto
    {
        [Key]
        public Guid ItemsID { get; set; }

        [Display(Name = "Item Name")]
        [Required(ErrorMessage = "Item Name is Required!")]
        public string ItemName { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is Required!")]
        public decimal Price { get; set; }

        //[Display(Name = "Item Image")]
        //[Required(ErrorMessage = "Item Image is Required!")]
        public string ItemImage { get; set; }
        public Guid UserID { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }






    }
}
