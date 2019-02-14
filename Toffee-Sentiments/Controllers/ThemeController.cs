using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Toffee_Sentiments.ViewModels;
using Toffee_Sentiments.Models;

namespace Toffee_Sentiments.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult getTheme(ThemeModelView themeModelView)
        {
            string getThemeName = themeModelView.getTheme;
            TempStorage.Theme = getThemeName;
            return RedirectToAction("Index", "Stamp");
        }
    }
}