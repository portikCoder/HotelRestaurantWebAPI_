using HotelRestaurantAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using DAL.Entities;
using System.Security.Cryptography;
using System.Text;
using HotelRestaurantAPI.Exceptions;

namespace HotelRestaurantAPI.BL
{
    public static class AccountManager
    {
        public static User CreateUser(RegisterDTO registerDTO, HotelRestaurantDBContext dBContext)
        {
            User user = new User();
            string salt = CreateSalt();
            user.UserName = registerDTO.UserName;
            user.Salt = salt;
            user.Password = EncryptPassword(registerDTO.Password, salt);
            dBContext.Users.Add(user);
            dBContext.SaveChanges();

            return user;
        }

        public static User CheckUserLogin(LoginDTO loginDTO, HotelRestaurantDBContext dBContext)
        {
            User user = dBContext.Users.Where(u => u.UserName.Equals(loginDTO.UserName)).FirstOrDefault();

            if (user == null)
            {
                throw new UserNotExistsException();
            }

            if (user.Password.Equals(EncryptPassword(loginDTO.Password, user.Salt)))
            {
                return user;
            }
            else
            {
                throw new InvalidPasswordException();
            }
        }



        /// <summary>
        ///     Creates a random salt to be used for encrypting a password
        /// </summary>
        /// <returns></returns>
        public static string CreateSalt()
        {
            var data = new byte[0x10];
            using (var cryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                cryptoServiceProvider.GetBytes(data);
                return Convert.ToBase64String(data);
            }
        }

        /// <summary>
        ///     Encrypts a password using the given salt
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string EncryptPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = string.Format("{0}{1}", salt, password);
                var saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
                return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
            }
        }

    }
}