using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyClothesMVC.Models
{
    public static class SessionHelper
    {
        private const string ID_KEY = "Id";
        private const string USERNAME_KEY = "Username";

        public static void CreateUserSession(int id, string username, IHttpContextAccessor http) 
        {
            http.HttpContext.Session.SetInt32(ID_KEY, id);
            http.HttpContext.Session.SetString(USERNAME_KEY, username);
        }

        /// <summary>
        /// Returns true if the user is logged in
        /// </summary>
        /// <param name="http"></param>
        /// <returns></returns>
        public static bool IsUserLoggedIn(IHttpContextAccessor http) 
        {
            if (http.HttpContext.Session.GetInt32(ID_KEY).HasValue) //If they have an user Id stored in session
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Logs user out
        /// </summary>
        /// <param name="http"></param>
        public static void DestroyUserSession(IHttpContextAccessor http) 
        {
            http.HttpContext.Session.Clear();
        }
    }
}
