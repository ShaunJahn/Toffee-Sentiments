using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Toffee_Sentiments.DbContexts;

namespace Toffee_Sentiments.Models
{
    public class ShoppingCart
    {
        private CardsDbContext _Context;

        public ShoppingCart(CardsDbContext cardsDbContext)
        {
            _Context = cardsDbContext;
        }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItemDto> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<CardsDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddCart(CardCreationDto card, int amount)
        {
            var shoppingCartItem = new ShoppingCartItemDto
            {
                ShoppingCartID = ShoppingCartId,
                CardCreation = card,
                Amount = amount
            };

            _Context.ShoppingCartItems.Add(shoppingCartItem);


            _Context.SaveChanges();

        }

        public int RemoveFromCart(CardCreationDto card)
        {
            var shoppingCartItem = _Context.ShoppingCartItems.SingleOrDefault(c => c.ShoppingCartID == ShoppingCartId && c.CardCreation==card);
            var localAmount = 0;

            if (shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
                localAmount = shoppingCartItem.Amount;
            }
            else
            {
                _Context.ShoppingCartItems.Remove(shoppingCartItem);
            }
            _Context.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItemDto> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _Context.ShoppingCartItems.Include(c => c.CardCreation).Where(c => c.ShoppingCartID == ShoppingCartId).ToList());
        }

        public void ClearCart()
        {
            var cartItems = _Context
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartID == ShoppingCartId);

            _Context.ShoppingCartItems.RemoveRange(cartItems);

            _Context.SaveChanges();
        }



    }
}
