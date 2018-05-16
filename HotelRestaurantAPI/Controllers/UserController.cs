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
            /*test data*/

            return Ok(new[] { 
                new { Id = "room_404", Type = "bedroom", Subtype = "doubled penetratin", Properties = new string[] { "extra-large", "XXL" }, Others = new string[] { "mini-skirt", "ammm wardrobe", "mini refrigerator" }},
                new { Id = "room_406", Type = "bedroom", Subtype = "doubled penetratin", Properties = new string[] { "extra-large", "XXL" }, Others = new string[] { "mini-skirt", "ammm wardrobe", "mini refrigerator" }},
                new { Id = "room_408", Type = "bedroom", Subtype = "doubled penetratin", Properties = new string[] { "extra-large", "XXL" }, Others = new string[] { "mini-skirt", "ammm wardrobe", "mini refrigerator" }},
            });
        }

        [HttpPost]
        [Route("api2/userpreservations")]
        public IHttpActionResult GetPreservations(UserDTO user)
        {
            /* Get tthe lists of rooms from DB!!!! */
            List<Room> rooms = new List<Room>();

            /*test data*/
            /*test data*/

            return Ok(new[] {
                new { Id = "room_404", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), },
                new { Id = "room_406", StartDate = DateTime.Today.AddDays(4), EndDate = DateTime.Today.AddDays(7), },
                new { Id = "room_408", StartDate = DateTime.Today.AddDays(5), EndDate = DateTime.Today.AddDays(6), },
            });
        }

        [HttpPost]
        [Route("api2/otheruserpreservations")]
        public IHttpActionResult GetOtherPreservations(UserDTO user)
        {
            /* Get tthe lists of rooms from DB!!!! */
            List<Room> rooms = new List<Room>();

            /*test data*/
            /*test data*/

            return Ok(new[] {
                new { Id = "room_404", StartDate = DateTime.Now.AddDays(2), EndDate = DateTime.Now.AddDays(4), },
                new { Id = "room_406", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(9), },
                new { Id = "room_408", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(10), },
                new { Id = "room_409", StartDate = DateTime.Today.AddDays(2), EndDate = DateTime.Today.AddDays(10), },
            });
        }
    }
}
