﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TinyClothesMVC.Models
{
    public class SearchCritetia
    {
        //This constructor makes sure it's always initialized
        public SearchCritetia()
        {
            Results = new List<Clothing>();
        }

        public string Size { get; set; }

        /// <summary>
        /// The type of clothing, shirt/pants/hat/etc
        /// </summary>
        public string Type { get; set; }

        public string Title { get; set; }

        [Display(Name = "Minimum Price")]
        [Range(0, double.MaxValue, ErrorMessage = "The minimum price must be a positive number")]
        public double? MinPrice { get; set; }

        [Display(Name = "Maximum Price")]
        [Range(0, double.MaxValue, ErrorMessage = "The minimum price must be a positive number")]
        public double? MaxPrice { get; set; }

        /// <summary>
        /// All Clothing items found using the search criteria
        /// </summary>
        public List<Clothing> Results { get; set; }
    }
}