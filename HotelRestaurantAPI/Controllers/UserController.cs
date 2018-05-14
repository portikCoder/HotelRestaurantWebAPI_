using DAL;
using DAL.Entities;
using HotelRestaurantAPI.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelRestaurantAPI.Controllers
{
    public class UserController : ApiController
    {
        private HotelRestaurantDBContext DBContext = new HotelRestaurantDBContext();

        [HttpPost]
        [Route("api2/rooms")]
        public IHttpActionResult GetRooms(UserDTO user)
        {
            /* Get tthe lists of rooms from DB!!!! */
            List<Room> rooms = new List<Room>();

            /*test data*/
            List<(string Id, string Type, string Subtype, string[] Properties, string[] Others)> rooms_t = new List<(string Id, string Type, string Subtype, string[] Properties, string[] Others)>(){
                ("room_404", "bedroom", "doubled penetratin", new string[] { "extra-large", "XXL"}, new string[] { "mini-skirt", "ammm wardrobe", "mini refrigerator" }),
                ("room_406", "bedroom", "doubled penetratin", new string[] { "extra-large", "XXL"}, new string[] { "mini-skirt", "ammm wardrobe", "mini refrigerator" }),
                ("room_408", "bedroom", "doubled penetratin", new string[] { "extra-large", "XXL"}, new string[] { "mini-skirt", "ammm wardrobe", "mini refrigerator" }),

            };
            /*test data*/

            //return Ok(new[] { "room_404", "bedroom", "doubled penetratin", new string[] { "extra-large", "XXL" }, new string[] { "mini-skirt", "ammm wardrobe", "mini refrigerator" } }.ToList());
            //return Ok( new { "data" = 1, "data2" = 2, "data3" = 3 } );
            return Ok(new[] { 
                new { Id = "room_404", Type = "bedroom", Subtype = "doubled penetratin", Properties = new string[] { "extra-large", "XXL" }, Others = new string[] { "mini-skirt", "ammm wardrobe", "mini refrigerator" }},
                new { Id = "room_406", Type = "bedroom", Subtype = "doubled penetratin", Properties = new string[] { "extra-large", "XXL" }, Others = new string[] { "mini-skirt", "ammm wardrobe", "mini refrigerator" }},
                new { Id = "room_408", Type = "bedroom", Subtype = "doubled penetratin", Properties = new string[] { "extra-large", "XXL" }, Others = new string[] { "mini-skirt", "ammm wardrobe", "mini refrigerator" }},
            });
        }
    }
}
