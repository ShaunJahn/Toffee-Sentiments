using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toffee_Sentiments.Models;
using Toffee_Sentiments.DbContexts;
using Toffee_Sentiments.ViewModels;

namespace Toffee_Sentiments.Repository
{
    public class CardsOfTheMonthRepositoryFromDatabase : ICardsOfTheMonth
    {
        private CardsDbContext _Context;

        public CardsOfTheMonthRepositoryFromDatabase(CardsDbContext cardsDbContext)
        {
            _Context = cardsDbContext;
        }

        public IEnumerable<CardsOfTheMonthDto> CardsOfTheMonths()
        {
           return _Context.CardsOfTheMonths.ToList();
        }
    }
}
