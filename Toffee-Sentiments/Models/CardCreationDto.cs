using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Toffee_Sentiments.Models
{
    public class CardCreationDto
    {
        public int Id { get; set; }
        public string Template { get; set; }
        public string Theme { get; set; }
        public string Stamp { get; set; }
        public string Message { get; set; }
    }
}
