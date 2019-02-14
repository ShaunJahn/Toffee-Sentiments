using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Toffee_Sentiments.Models
{
    public class ShoppingCartItemDto
    {
        public int Id { get; set; }
        public CardCreationDto CardCreation { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartID { get; set; }
    }
}
