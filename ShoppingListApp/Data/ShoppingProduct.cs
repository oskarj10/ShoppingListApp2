using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingListApp.Data
{
    public class ShoppingProduct
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa produktu jest wymagana.")]
        [Display(Name = "Nazwa produktu")]
        public string ProductName { get; set; } = string.Empty; 

        [Display(Name = "Czy zaznaczone")]
        public bool IsChecked { get; set; }

        public int ShoppingListId { get; set; }
        public ShoppingListItem? ShoppingList { get; set; } 

        public string OwnerId { get; set; } = string.Empty; 
        public ApplicationUser? Owner { get; set; } 

        public ShoppingProduct()
        {
        }
    }
}




