using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingApplication.Models.Home
{
    public class CartItems
    {
        public string Name { get; set; }
        public double Subtotal { get; set; }

        public int Quantity { get; set; }
    }
}
