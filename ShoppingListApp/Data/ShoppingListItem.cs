using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingListApp.Data
{
    public class ShoppingListItem
    {
        public int Id { get; set; }
        public string ListName { get; set; } = string.Empty;
        public DateTime ShoppingDate { get; set; }
        public List<ShoppingProduct> Products { get; set; } = new List<ShoppingProduct>();
    }
}

public class FutureOrPresentDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateTime)
            {
                if (dateTime.Date >= DateTime.Now.Date)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return new ValidationResult("Invalid date format.");
        }
    }






