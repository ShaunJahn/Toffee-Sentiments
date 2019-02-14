using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Toffee_Sentiments.Models;

namespace Toffee_Sentiments.DbContexts
{
    public class CardsDbContext : IdentityDbContext<IdentityUser>
    {
        public CardsDbContext(DbContextOptions<CardsDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<CardsOfTheMonthDto> CardsOfTheMonths { get; set; }
        public DbSet<CardCreationDto> CardCreations { get; set; }
        public DbSet<ShoppingCartItemDto> ShoppingCartItems { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
