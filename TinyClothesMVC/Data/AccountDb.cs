using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyClothesMVC.Models;

namespace TinyClothesMVC.Data
{
    public static class AccountDb
    {
        public async static Task<bool> IsUsernameTaken(string username, StoreContext context)
        {
            bool isTaken = await (from a in context.Accounts
                         where username == a.Username
                         select a).AnyAsync();
            return isTaken;
            //return await context.Accounts.Where(a => a.Username == username.Trim()).AnyAsync();
        }

        public static async Task<Account> Register(StoreContext context, Account acc)
        {
            await context.Accounts.AddAsync(acc);
            await context.SaveChangesAsync();
            return acc;
        }
    }
}
