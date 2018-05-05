using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelRestaurantAPI.DTO
{
    public class LoginDTO
    {
        public string UserName;
        public string Password;

        public LoginDTO(string un, string pwd)
        {
            UserName = un;
            Password = pwd;
        }
    }
}