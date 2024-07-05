using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Data
{
    public class ShoppingListItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa listy jest wymagana.")]
        [Display(Name = "Nazwa listy")]
        public string ListName { get; set; } = string.Empty; 

        [FutureOrPresentDate(ErrorMessage = "Data zakupów nie może być w przeszłości.")]
        [Display(Name = "Data zakupów")]
        public DateTime ShoppingDate { get; set; }

        [Display(Name = "Opis")]
        public string? Description { get; set; } 

        [Display(Name = "Zaznaczone")]
        public bool IsChecked { get; set; }

        public List<ShoppingProduct> Products { get; set; } = new List<ShoppingProduct>(); 

        public string OwnerId { get; set; } = string.Empty; 
        public ApplicationUser? Owner { get; set; } 

        public ShoppingListItem()
        {
           
        }
    }

    public class FutureOrPresentDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;
            return date >= DateTime.Today;
        }
    }
}










