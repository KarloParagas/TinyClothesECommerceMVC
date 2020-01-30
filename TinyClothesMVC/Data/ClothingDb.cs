using Microsoft.EntityFrameworkCore;
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
        //If you wanted page 1, we woouldn't skip ay rows, so we must offset by 1
        const int PAGE_OFFSET = 1;

        /// <summary>
        /// Returns a specific page of clothing items sorted by ItewmId in ascending order
        /// </summary>
        /// <param name="context">The DB context passed from the clothes controller</param>
        /// <param name="pageNum">The page</param>
        /// <param name="pageSize">Number of Clothing per page</param>
        public static async Task<List<Clothing>> GetClothingByPage(StoreContext context, int pageNum, int pageSize) //StoreContext context gets passed 
                                                                                                                    //from the clothes controller
        {
            //LINQ Method Syntax
            List<Clothing> clothes = await context.Clothing
                                                  .OrderBy(c => c.ItemId)
                                                  .Skip((pageNum - PAGE_OFFSET) * pageSize)
                                                  .Take(pageSize)
                                                  .ToListAsync(); //Note: Order matters on this

            //LINQ Query Syntax
            //List<Clothing> clothes2 = await (from c in context.Clothing
            //                                 orderby c.ItemId ascending
            //                                 select c)
            //                                .Skip((pageNum - PAGE_OFFSET) * pageSize)
            //                                .Take(pageSize)
            //                                .ToListAsync(); //Note: Order matters on this

            return clothes;
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
