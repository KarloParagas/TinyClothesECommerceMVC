using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TinyClothesMVC.Data;

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
            return View();
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }
    }
}