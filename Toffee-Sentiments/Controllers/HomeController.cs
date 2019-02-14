using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Toffee_Sentiments.ViewModels;
using Toffee_Sentiments.Repository;
using System.Net.Mail;
using System.Net;

namespace Toffee_Sentiments.Controllers
{
    public class HomeController : Controller
    {
        private ICardsOfTheMonth _repositoryCardsOfTheMonth;

        public HomeController(ICardsOfTheMonth cardsOfTheMonth)
        {
            _repositoryCardsOfTheMonth = cardsOfTheMonth;
        }

        public IActionResult Index()
        {
            var returnViewModel = new HomePageViewModel()
            {
                CardsOfTheMonthViewModel = new CardsOfTheMonthViewModel { CardsOfTheMonths = _repositoryCardsOfTheMonth.CardsOfTheMonths() },
                ContactFormViewModel = new ContactFormViewModel { } 
            };

            return View(returnViewModel);
        }

        [HttpPost]
        public IActionResult contact(HomePageViewModel homePage)
        {
            string name    = homePage.ContactFormViewModel.UserName,
                   email   = homePage.ContactFormViewModel.Email,
                   messageSend = homePage.ContactFormViewModel.Message;


            using (var message = new MailMessage(email, "MrJshaun@gmail.com"))
            {
                message.To.Add(new MailAddress("Mrjshaun@gmail.com"));
                message.From = new MailAddress(email);
                message.Subject = "Contact Form Email adress";
                message.Body = messageSend;

                using (var smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("mrjshaun@gmail.com", "pxnfynzwjbvnnuss");
                    smtpClient.Send(message);
                }

                return RedirectToAction("index");
            }
        }


    }
}