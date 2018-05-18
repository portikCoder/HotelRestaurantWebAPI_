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
        [Authorize(Users = "Admin1")]
        //[Route("api/rooms")]
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

            /*
             * 
             "Approved" == 1
             "Pending" == 0
             */

            return Ok(new[] {
                new { Id = "room_404", StartDate = DateTime.Now.AddDays(0), EndDate = DateTime.Now.AddDays(2), Status = 1, Price=(1000)},
                new { Id = "room_406", StartDate = DateTime.Today.AddDays(4), EndDate = DateTime.Today.AddDays(7), Status = 0, Price=(5500)},
                new { Id = "room_408", StartDate = DateTime.Today.AddDays(5), EndDate = DateTime.Today.AddDays(6), Status = 0, Price=(750)},
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
                //new { Id = "room_406", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(9), },
                new { Id = "room_406", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(9), },
                new { Id = "room_408", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(10), },
                new { Id = "room_409", StartDate = DateTime.Today.AddDays(2), EndDate = DateTime.Today.AddDays(10), },
            });
        }

        [HttpPost]
        [Route("api2/bookings")]
        public IHttpActionResult GetBookings(/*BookingDTO booking*/)
        {
            return Ok();
        }

        [HttpPost]
        [Route("api2/dateFilter")]
        public IHttpActionResult FilterByDate(/*DateFilterDTO booking*/)
        {
            return Ok();
        }

        [HttpPost]
        [Route("api2/deleteBooking")]
        public IHttpActionResult DeleteBooking(/*BookingEditDTO booking*/)
        {
            return Ok();
        }

        [HttpPost]
        [Route("api2/changeBooking")]
        public IHttpActionResult ChangeBooking(/*BookingEditDTO booking*/)
        {
            return Ok();
        }
    }
}
