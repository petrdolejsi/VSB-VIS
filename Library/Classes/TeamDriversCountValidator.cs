using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Library.Mapping;
using Library.Models;

namespace Library.Classes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class TeamDriversCountValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                try
                {
                    var driversMapper = new DriversMapper();
                    var number = (Teams)value;


                    if (driversMapper.SelectCountDrivers(number.Id) >= 2 && ((Library.Models.Drivers)validationContext.ObjectInstance).Team.Id != number.Id)
                    {
                        return new ValidationResult("Tým již má přidělené 2 jezdce.");
                    }
                    
                }
                catch (Exception)
                {
                    return new ValidationResult("Špatně vybraný tým.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
