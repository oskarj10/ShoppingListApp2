using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Data
{
    public class ShoppingListItem
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nazwa listy")]
        public string ListName { get; set; }

        [FutureOrPresentDate(ErrorMessage = "Shopping Date cannot be in the past.")]
        [Display(Name = "Data zakupów")]
        public DateTime ShoppingDate { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }
        public List<ShoppingProduct> Products { get; set; }

        // Dodaj właściwość Owner
        public ApplicationUser Owner { get; set; } // Zakładając, że ApplicationUser jest klasą reprezentującą właściciela
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







