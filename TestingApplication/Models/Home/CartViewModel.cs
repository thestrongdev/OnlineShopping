using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingApplication.Models.Home
{
    public class CartViewModel
    {
        public List<CartItems> ShopperCart { get; set; }
        public double Total { get; set; }
    }
}
