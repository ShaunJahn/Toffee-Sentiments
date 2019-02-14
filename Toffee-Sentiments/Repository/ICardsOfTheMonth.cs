using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toffee_Sentiments.Models;
using Toffee_Sentiments.ViewModels;

namespace Toffee_Sentiments.Repository
{
    public  interface ICardsOfTheMonth
    {
        //get from database
        IEnumerable<CardsOfTheMonthDto> CardsOfTheMonths();
    }
    

 }
