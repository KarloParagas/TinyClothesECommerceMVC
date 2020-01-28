using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyClothesMVC.Models;

namespace TinyClothesMVC.Data
{
    /// <summary>
    /// Contains DB helper methods for Clothing for <see cref="Models.Clothing"/>
    /// </summary>
    public static class ClothingDb
    {
        public static List<Clothing> GetAllClothing() 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a clothing object to the database. Returns the object with the Id populated.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static async Task<Clothing> Add(Clothing c, StoreContext context) 
        {
            await context.AddAsync(c); //Prepares INSERT query
            await context.SaveChangesAsync(); //Execute INSERT query
            return c;
        }

        //NOTE: All database code should be Asynchronous
    }
}
