using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelRestaurantAPI.Exceptions
{
    public class IncorrectPwdConfirmationException : Exception
    {
        public IncorrectPwdConfirmationException() : base("Incorrect password confirmation!")
        {

        }
    }
}