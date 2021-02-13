using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestingApplication.DALModels
{
    public class StoreDAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public IEnumerable<CartDAL> ShopperItems { get; set; }

    }
}
