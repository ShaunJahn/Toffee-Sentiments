using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toffee_Sentiments.DbContexts;
using Toffee_Sentiments.Models;
using Toffee_Sentiments.Repository;


namespace Toffee_Sentiments.Repository
{
    public class OrderRespository : IOrderRepository
    {
        private CardsDbContext _context;
        private ShoppingCart _shoppingCart;

        public OrderRespository(CardsDbContext dbContext, ShoppingCart shoppingCart)
        {
            _context = dbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _context.Orders.Add(order);
            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCart in shoppingCartItems)
            {
                var OrderDetails = new OrderDetail()
                {
                    Amount = shoppingCart.Amount,
                    card = shoppingCart.CardCreation,
                    OrderId = order.OrderId
                };

                _context.OrderDetails.Add(OrderDetails);
            }

            _context.SaveChanges();
        }
    }
}
