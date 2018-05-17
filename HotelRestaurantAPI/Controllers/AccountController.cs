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
using System.Data.Entity.Validation;
using HotelRestaurantAPI.Models;

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
            RoomRepository test = new RoomRepository();
          
            
            try
            {



                test.AddEquipment("table");
                test.AddEquipment("tv");
                AdminManager.addSubType("double pen");
                AdminManager.AddProperties("XXL");
                List<Equipment> q = new List<Equipment>();
                q = AdminManager.GetAllEquipment();
                List<Properties> e = new List<Properties>();
                e = AdminManager.GetAllProperti();
                Room room = new Room();
                room.Price = 12;
                room.Id = 12;
                //room.Id = 11;
                RoomModel roomModel = new RoomModel();
                roomModel.PropertisList = e;
                roomModel.EquipmentList = q;
                roomModel.room = room;
                AdminManager.AddRoom(roomModel);
                //test.AddRoomEquipment(1, "tv");
                //test.AddRoomEquipment(1, "table");
                //test.GetRoomEquipment(1);

                //AdminManager.addRoomSubType("double pen", 1);
                //Reservation t = new Reservation();
                //t.price = 30;
                //t.createReservation = DateTime.Today;
                //t.startDate = DateTime.Today.AddDays(8);
                //t.finishDate = DateTime.Today.AddDays(12);
                //t.status = 0;

                //List<int> rt = new List<int>();
                //rt.Add(1);
                //AdminManager.AddReservation(rt, t);


                //test.GetRoomEquipment(1);

                //AdminManager.AddRoomProperties(1, "XXL");
                //List<RoomModel> tu = AdminManager.GetAllRoomByDate(DateTime.Today.AddDays(8), DateTime.Today.AddDays(9));
                //AdminManager.GetAllRoomByDate(DateTime.Today.AddDays(8), DateTime.Today.AddDays(8));

            }catch(Exception e)
            {
                BadRequest(e.Message);
            }
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
            var userTuple = new System.Tuple<string,string,string>(user.UserName,user.Status,token);

            return Ok(new { username = user.UserName, status = user.Status, token = token });
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
                DBContext.Users.Add(user);
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
