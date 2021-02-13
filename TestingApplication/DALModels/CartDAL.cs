using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestingApplication.DALModels
{
    public class CartDAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShopperItemId { get; set; }
        public int ItemQuantity { get; set; }

        public string ItemName { get; set; }

        public double SubTotal { get; set; }

        [ForeignKey("StoreDAL")]
        public int ItemId { get; set; }
        public StoreDAL StoreDAL { get; set; }

        [ForeignKey("AspNetUsers")]
        public string Id { get; set; }
        public IdentityUser User { get; set; }


    }
}
