using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Toffee_Sentiments.ViewModels;
using Toffee_Sentiments.Models;

namespace Toffee_Sentiments.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult getMessage(MessageViewModel messageViewModel)
        {
            string getMessage = messageViewModel.getMessage;
            TempStorage.Message = getMessage;
            return RedirectToAction("AddToShoppingCart", "ShoppingCart");
        }

    }
}