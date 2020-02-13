using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TinyClothesMVC.Data;
using TinyClothesMVC.Models;

namespace TinyClothesMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly StoreContext _context;

        public AccountController(StoreContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel reg) 
        {
            if (ModelState.IsValid) 
            {
                //Check if username is not taken
                if (await AccountDb.IsUsernameTaken(reg.Username, _context))
                {
                    Account acc = new Account()
                    {
                        Email = reg.Email,
                        FullName = reg.FullName,
                        Password = reg.Password,
                        Username = reg.Username
                    };

                    //Add Account to DB
                    await AccountDb.Register(_context, acc);
                    return RedirectToAction("Index", "Home");
                }
                else //If username is taken, add error
                {
                    //Display error with other username error messages
                    //ModelState.AddModelError(string.Empty, "Username is taken");
                    ModelState.AddModelError(nameof(Account.Username), "Username is taken");
                }

                //Add account to DB
            }
            return View(reg);
        }
    }
}