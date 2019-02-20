using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Classes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class DateValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                try
                {
                    DateTime _date = Convert.ToDateTime(value);
                    if ((DateTime.Now - _date).TotalDays < (365 * 15))
                    {
                        return new ValidationResult("Jezdec nesmí mít méně, než 15 let.");
                    }
                }
                catch (Exception)
                {
                    return new ValidationResult("Špatně zadané datum.");
                }
            }
            else
            {
                return new ValidationResult("Datum je povinné.");
            }
            return ValidationResult.Success;
        }
    }
}
