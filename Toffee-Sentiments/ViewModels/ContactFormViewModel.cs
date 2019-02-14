using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Toffee_Sentiments.ViewModels
{
    public class ContactFormViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Emali")]        
        public string Email { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }

    }
}
