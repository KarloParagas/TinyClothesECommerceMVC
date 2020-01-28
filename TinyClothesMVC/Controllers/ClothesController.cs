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
        public IActionResult ShowAll()
        {
            //Just a placeholder s0 when clicking the Inventory like doesn't crash
            //It's so the value isnt null
            List<Clothing> clothes = new List<Clothing>();
            return View(clothes);
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