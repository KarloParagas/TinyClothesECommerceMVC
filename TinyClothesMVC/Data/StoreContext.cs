﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyClothesMVC.Models;

namespace TinyClothesMVC.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        
        }

        //Add a DbSet for each Entity that needs to be tracked by the DB
        //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-3.1#create-the-database-context
        public DbSet<Clothing> Clothing { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
