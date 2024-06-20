using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingListApp.Data
{
    public class ShoppingProduct
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa produktu jest wymagana.")]
        [Display(Name = "Nazwa produktu")]
        public string ProductName { get; set; }

        [Display(Name = "Czy zaznaczone")]
        public bool IsChecked { get; set; }

        // ForeignKey to ShoppingListItem
        public int ShoppingListId { get; set; }
        public ShoppingListItem ShoppingList { get; set; }

        // Owner property assuming ApplicationUser is a class representing the owner
        public string OwnerId { get; set; } // ForeignKey
        public ApplicationUser Owner { get; set; }
    }
}



