using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Toffee_Sentiments.Models;
using Toffee_Sentiments.ViewModels;

namespace Toffee_Sentiments.Compenents
{
    public class ShoppingCartSummary : ViewComponent
    {
        private ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
            };

            return View(shoppingCartViewModel);
        }


    }
}
