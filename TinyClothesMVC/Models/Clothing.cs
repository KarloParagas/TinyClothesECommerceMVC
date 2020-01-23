using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TinyClothesMVC.Models
{
    /// <summary>
    /// Represents a single clothing item
    /// </summary>
    public class Clothing
    {
        /// <summary>
        /// The unique ID for the clothing item
        /// </summary>
        [Key] //This sets it as a primary key
        public int ItemId { get; set; }

        /// <summary>
        /// The size of the clothing (small, meduim, large)
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// The type of clothing, shirt, pants, etc
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The color of the clothing item
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Retail price of the item
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// The display title of the clothing item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description of the clothing
        /// </summary>
        public string Description { get; set; }
    }
}
