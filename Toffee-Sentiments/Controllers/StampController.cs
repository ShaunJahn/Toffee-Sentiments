using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Toffee_Sentiments.ViewModels;
using Toffee_Sentiments.Models;

namespace Toffee_Sentiments.Controllers
{
    public class StampController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult getStamp(StampModelView stampModelView)
        {
            string getStampName = stampModelView.getStamp;
            TempStorage.Stamp = getStampName;
            return RedirectToAction("Index", "Message");
        }

    }
}