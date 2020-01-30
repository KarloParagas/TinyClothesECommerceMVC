using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TinyClothesMVC.Data;
using TinyClothesMVC.Models;

namespace TinyClothesMVC.Controllers
{
    public class ClothesController : Controller
    {
        private readonly StoreContext _context; //readonly means that only the constructor can modify this variable

        public ClothesController(StoreContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ShowAll(int? page) //page comes from "asp-route-page" in the ShowAll.cshtml (located in pagination ul)
        {
            const int PAGE_SIZE = 2;

            //Null-Coalescing operator https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
            int pageNumber = page ?? 1;

            int maxPage = await GetMaxPage(PAGE_SIZE);

            ViewData["MaxPage"] = maxPage; //This makes maxPage accessible to the ShowAll.cshtml

            ////Just a placeholder s0 when clicking the Inventory like doesn't crash
            ////It's so the value isnt null
            //List<Clothing> clothes = new List<Clothing>();

            List<Clothing> clothes = await ClothingDb.GetClothingByPage(_context, pageNum: pageNumber, pageSize: PAGE_SIZE);
            return View(clothes);
        }

        private async Task<int> GetMaxPage(int PAGE_SIZE)
        {
            int numProducts = await ClothingDb.GetNumClothing(_context);
            int maxPage = Convert.ToInt32(Math.Ceiling((double)numProducts / PAGE_SIZE));
            return maxPage;
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Clothing c) 
        {
            if (ModelState.IsValid) 
            {
                await ClothingDb.Add(c, _context);

                //TODO: Add a success message after reditrect
                //TempData lasts for one redirect
                TempData["Message"] = $"{c.Title} Clothing added successfully";

                return RedirectToAction("ShowAll");
            }

            //Return same view with validation messages
            return View();
        }
    }
}