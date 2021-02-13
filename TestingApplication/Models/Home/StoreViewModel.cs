using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingApplication.Models.Home
{
    public class StoreViewModel
    {
        public List<StoreItems> TheStore { get; set; }

        public int Quantity { get; set; }

        public StoreItems ItemToAdd { get; set; }
    }
}
