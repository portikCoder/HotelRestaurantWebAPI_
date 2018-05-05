using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelRestaurantAPI.Exceptions
{
    public class UserNotExistsException : Exception
    {
        public UserNotExistsException() : base("The user does not exist!")
        {

        }
    }
}