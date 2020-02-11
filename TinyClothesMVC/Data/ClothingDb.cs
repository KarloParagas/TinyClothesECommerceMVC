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
        /// <summary>
        /// Returns the total number of Clothing items
        /// </summary>
        /// <returns></returns>
        public async static Task<int> GetNumClothing(StoreContext context) 
        {
            return await context.Clothing.CountAsync();

            //Alternate with query syntax
            //return await (from c in context.Clothing
            //              select c).CountAsync();
        }

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

        public static async Task<Clothing> Edit(Clothing c, StoreContext context)
        {
            await context.AddAsync(c);
            context.Entry(c).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return c;
        }

        /// <summary>
        /// Returns a single clothing item or null if there is no match
        /// </summary>
        /// <param name="id">The id of the clothing item</param>
        /// <param name="context">DB Context</param>
        public static async Task<Clothing> GetClothingById(int id, StoreContext context)
        {
            Clothing c = await (from clothing in context.Clothing
                                where clothing.ItemId == id
                                select clothing).SingleOrDefaultAsync();

            return c;
        }

        public static async Task Delete(int id, StoreContext context)
        {
            //Clothing c = new Clothing()
            //{
            //    ItemId = id
            //};

            //context.Entry(c).State = EntityState.Deleted; //This tells the Entity Framework that we have the clothing object, but we are removing it from the database
            //await context.SaveChangesAsync();
            Clothing c = await GetClothingById(id, context);

            if (c != null) 
            {
                await context.AddAsync(c);
                context.Entry(c).State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
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
