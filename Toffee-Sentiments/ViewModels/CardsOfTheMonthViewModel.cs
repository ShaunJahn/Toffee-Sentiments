﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toffee_Sentiments.Models;

namespace Toffee_Sentiments.ViewModels
{
    public class CardsOfTheMonthViewModel
    {
        public IEnumerable<CardsOfTheMonthDto> CardsOfTheMonths { get; set; }
    }
}
