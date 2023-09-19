using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientShoppingList.Shared
{
    public class ProductsViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "ProductName")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

      
        public string Img { get; set; }
    }   
}
