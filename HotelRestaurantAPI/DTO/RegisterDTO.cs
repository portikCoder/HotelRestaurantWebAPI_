using HotelRestaurantAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelRestaurantAPI.DTO
{
    public class RegisterDTO
    {
        public string Email;
        public string UserName;
        public string FirstName;
        public string LastName;
        public string Password;

        public RegisterDTO(string email, string un, string fName, string lName, string pwd, string confirmPwd)
        {
            if (pwd != confirmPwd)
            {
                throw new IncorrectPwdConfirmationException();
            }
            else
            {
                Email = email;
                UserName = un;
                FirstName = fName;
                LastName = lName;
                Password = pwd;
            }


        }
    }
}