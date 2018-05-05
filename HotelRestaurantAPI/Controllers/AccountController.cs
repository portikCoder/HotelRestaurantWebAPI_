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
