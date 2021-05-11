using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CW4.Models
{
    public class Animal
    {
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$"
            ,ErrorMessage = "W nazwie zwierzęcie nie można stosowac cyfr")]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category   { get; set; }
        [Required]
        public string Area { get; set; }
    }
}
