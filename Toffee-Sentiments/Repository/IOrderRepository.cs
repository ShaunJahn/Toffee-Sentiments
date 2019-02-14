using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toffee_Sentiments.Models;

namespace Toffee_Sentiments.Repository
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
