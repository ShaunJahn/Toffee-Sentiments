using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Toffee_Sentiments.DbContexts;
using Toffee_Sentiments.Models;
using Toffee_Sentiments.Repository;

namespace Toffee_Sentiments.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _orderRepository;
        private ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is emtpy, add some items first");
            }

            if (ModelState.IsValid)
            {
                Email(order);
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutCompleted");
            }
            return View(order);

        }

        private void Email(Order orderEmail)
        {
            string firstName = orderEmail.FirstName,
                    lastName = orderEmail.LastName,
                    email = orderEmail.Email;


            string messageSend = "Name:  " + orderEmail.FirstName + " " + orderEmail.LastName + "\n" +
                                 "Cell Number: " + orderEmail.PhoneNumber + "\n" +
                                  "Email: " + email + "\n";

            int count = 0;

            foreach (var item in _shoppingCart.ShoppingCartItems)
            {
                count++;

                messageSend += "Card:" + count + "  " + item.CardCreation.Template + "\n" +
                                "Theme: " + item.CardCreation.Theme + "\n" +
                                "Stamp: " + item.CardCreation.Stamp + "\n" +
                                "Message: " + item.CardCreation.Message + "\n" + "\n";
            }


            using (var message = new MailMessage(email, ""))
            {
                message.To.Add(new MailAddress(email));
                message.From = new MailAddress(email);
                message.Subject = "Order";
                message.Body = messageSend;

                using (var smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("");
                    smtpClient.Send(message);
                }


            }
        }

        public IActionResult CheckoutCompleted()
        {
            ViewBag.CheckoutCompleteMessage = HttpContext.User.Identity.Name +
                                      ", thanks for your order. You'll soon enjoy our awesome cards!";
            return View();
        }
    }
}