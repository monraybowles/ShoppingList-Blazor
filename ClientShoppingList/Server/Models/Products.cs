using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientShoppingList.Server.Models
{
    [Table("Products", Schema ="dbo")]
    public class Products
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int Id { get; set; }
        public string ProductName { get; set; }       
        public string Description { get; set; }       
        public decimal Price { get; set; }    
        public string Img { get; set; }
    }
}
