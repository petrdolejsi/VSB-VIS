using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Library.Classes;

namespace Library.Models
{
    public class Drivers
    {
        public int Id { get; set; }

        [DisplayName("Jméno")]
        [Required(ErrorMessage = "Jméno je povinné")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Ve jméně se nesmí nacházet číslice")]
        public string FirstName { get; set; }

        [DisplayName("Příjmení")]
        [Required(ErrorMessage = "Příjmení je povinné")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "V příjmení se nesmí nacházet číslice")]
        public string LastName { get; set; }

        [DisplayName("Číslo jezdce")]
        public int? Number { get; set; }

        [DisplayName("Datum narození")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Datum narození je povinné")]
        [DateValidator(ErrorMessage = "Jezdec nesmí mít méně, než 15 let")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Tým")]
        [TeamDriversCountValidator(ErrorMessage = "Tým již má přidělené 2 jezdce")]
        public Teams Team { get; set; }

        [DisplayName("Národnost")]
        [Required(ErrorMessage = "Národnost je povinná")]
        public States State { get; set; }
    }
}
