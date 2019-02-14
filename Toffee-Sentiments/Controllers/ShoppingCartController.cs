using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Toffee_Sentiments.Repository;
using Toffee_Sentiments.Models;
using Toffee_Sentiments.ViewModels;

namespace Toffee_Sentiments.Controllers
{
    public class ShoppingCartController : Controller
    {
       
        private ShoppingCart _shoppingCart;

        public ShoppingCartController(ShoppingCart shoppingCart)
        {
            
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart()
        {
            var card = new CardCreationDto()
            {
                Message = TempStorage.Message,
                Template = TempStorage.Template,
                Stamp = TempStorage.Stamp,
                Theme = TempStorage.Theme
            };

            if (card != null)
            {
                //maybe change number for user input
                _shoppingCart.AddCart(card, 1);
            }
            return RedirectToAction("Index");
        }


    }
}