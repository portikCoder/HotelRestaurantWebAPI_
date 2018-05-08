using DAL;
using HotelRestaurantAPI.BL;
using HotelRestaurantAPI.DTO;
using DAL.Entities;
using HotelRestaurantAPI.Exceptions;
using HotelRestaurantAPI.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelRestaurantAPI.Controllers
{
    public class AccountController : ApiController
    {
        private readonly bool C_DEBUG = true;

        private HotelRestaurantDBContext DBContext = new HotelRestaurantDBContext();
        [HttpPost]
        [Route("api2/login")]
        public IHttpActionResult Login(LoginDTO loginData)
        {
            User user;
            try
            {
                user = AccountManager.CheckUserLogin(loginData, DBContext);
            }
            catch (Exception e)
            {
                if (C_DEBUG)
                {
                    return BadRequest(e.Message);
                }
                if (new[] { typeof(UserNotExistsException) }.Any(t => t.IsAssignableFrom(e.GetType())))
                {
                    // it is a known EXEPTION then:
                    return BadRequest(e.Message);
                }
                else
                {
                    return BadRequest("Uknown Request+Error, so sorry maaan...");
                }
                if (e.GetType().IsAssignableToAnyOf(typeof(UserNotExistsException)))
                {
                    return BadRequest(e.Message);
                }
                return BadRequest(e.Message);
            }


            string token = Utility.TokenManager.CreateToken(user);
            return Ok(token);
        }



        [HttpPost]
        [Route("api2/signup")]
        public IHttpActionResult Register(RegisterDTO registrationData)
        {
            string token;
            User user;
            DAL.Entities.Room room = RoomManager.FirstConfigureRoom();

            try
            {
                user = AccountManager.CreateUser(registrationData, DBContext);
                room = RoomManager.FirstConfigureRoom();
                DBContext.Rooms.Add(room);
                user.Room = room;
                DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            token = Utility.TokenManager.CreateToken(user);
            return Ok(token);
        }

    }
}
