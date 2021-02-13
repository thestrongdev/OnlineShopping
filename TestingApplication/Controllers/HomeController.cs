using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using TestingApplication.DALModels;
using TestingApplication.Data;
using TestingApplication.Models;
using TestingApplication.Models.Home;

namespace TestingApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _applicationDbContext;

        public HomeController(ILogger<HomeController> logger,
            UserManager<IdentityUser> userManager,
            ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult DisplayStoreItems()
        {
            var viewModel = new StoreViewModel();

            viewModel.TheStore = _applicationDbContext.StoreItems.Select(
                storeDAL => new StoreItems
                {
                    Name = storeDAL.Name,
                    Price = storeDAL.Price,
                    
                }).ToList();

            return View("Store", viewModel);
        }

        public IActionResult AddToCart(string name, int qty)
        {

           StoreDAL storeDAL = _applicationDbContext.StoreItems
                .Where(item => item.Name == name).FirstOrDefault();

            var cartItem = new CartDAL();
            cartItem.ItemName = storeDAL.Name;
            cartItem.ItemQuantity = qty;
            cartItem.SubTotal = qty * storeDAL.Price;
            cartItem.ItemId = storeDAL.ItemId;
            cartItem.Id = _userManager.GetUserId(User);

            _applicationDbContext.ShopperCart.Add(cartItem);
            _applicationDbContext.SaveChanges();

            var viewModel = new SuccessfulAddToCartViewModel();
            viewModel.Subtotal = cartItem.SubTotal;
            viewModel.Name = cartItem.ItemName;

            return View("SuccessfulAddToCart", viewModel);
        }

        public IActionResult DisplayShopperItems()
        {
            var viewModel = new CartViewModel();

            viewModel.ShopperCart = _applicationDbContext.ShopperCart
                .Select(item => new CartItems { 
                    Name = item.ItemName, 
                    Quantity = item.ItemQuantity, 
                    Subtotal = item.SubTotal }).ToList();

            foreach(var item in viewModel.ShopperCart)
            {
                viewModel.Total += item.Subtotal;
            }

            return View("Cart", viewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
