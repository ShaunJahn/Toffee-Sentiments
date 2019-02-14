using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Toffee_Sentiments.ViewModels;
using Toffee_Sentiments.Models;

namespace Toffee_Sentiments.Controllers
{
    public class TemplateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult GetTemplateName(TemplateModelView templateModelView)
        {
             //user a static method for a temp
            string nameOfTemplate = templateModelView.getTemplate;
            TempStorage.Template = nameOfTemplate;
            return RedirectToAction("Index", "Theme");
        }


    }
}