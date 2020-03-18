using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyClothesMVC.Data;
using TinyClothesMVC.Models;

namespace TinyClothesMVC.Controllers
{
    public class CartController : Controller
    {
        //To read cookie data
        private readonly StoreContext _context;
        private readonly IHttpContextAccessor _http;

        public CartController(StoreContext context, IHttpContextAccessor http) 
        {
            _context = context;
            _http = http;
        }

        //Display all products in cart
        public IActionResult Index()
        {
            return View();
        }

        //Add a single product to the shopping cart
        public async Task<IActionResult> Add(int id, string prevUrl) 
        {
            Clothing c = await ClothingDb.GetClothingById(id, _context);

            if (c != null) 
            {
                CartHelper.Add(c, _http);
            }
            return Redirect(prevUrl);
        }

        public async Task<JsonResult> AddJS(int id) 
        {
            //Get id of clothing
            Clothing c = await ClothingDb.GetClothingById(id, _context);

            //Add clothing to the cart
            if (c == null) 
            {
                //Return not found message
            }
            CartHelper.Add(c, _http);

            //Send success response
            JsonResult result = new JsonResult("Success");
            result.StatusCode = 200; //Http ok
            return result;
        }

        //Summary/Checkout page
        public IActionResult Checkout() 
        {
            return View();
        }
    }
}