using DAL;
using DAL.Entities;
using HotelRestaurantAPI.BL;
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
    public class AdminController : ApiController
    {
        private HotelRestaurantDBContext DBContext = new HotelRestaurantDBContext();
        /*  For serving the subtype fields...
         * 
         */

        /*
         PENDING
         */
        [HttpGet]
        [Route("api2/subtypes")]
        public IHttpActionResult GetSubtypes(UserDTO user)
        {
            /* Get tthe lists of rooms from DB!!!! */
            List<Subtype> rooms = new List<Subtype>();
            rooms = AdminManager.GetSubtypes();

            /*test data*/
            var test1 = new { Subtype = new[] { "singled penetratin", "doubled penetratin", "tripled penetratin" } };
            /*test data*/

            return Ok(
                test1
            );
        }

        /*  For serving the extras fields...
         * 
         */
        [HttpGet]
        [Route("api2/extras")]
        public IHttpActionResult GetExtras()
        {
            /* Get tthe lists of rooms from DB!!!! */
            List<Equipment> others = AdminManager.GetOthers();

            /*test data*/
            var test1 = new { Others = new string[] { "mini-skirt", "ammm wardrobe", "mini refrigerator", "tele-vision..." } };
            /*test data*/

            return Ok(
                test1
            //equipments
            );
        }
        /*  Route for recieving the new room data [from the admin! / or not!].
         * 
         */
        /* PENDING */
        [HttpPost]
        [Route("api2/addnewroom")]
        public IHttpActionResult AddNewRoom(Models.ReservationModel newroom)
        {
            /* Get tthe lists of rooms from DB!!!! */
            List<Room> rooms = new List<Room>();

            /*test data*/
            var rooms_t = new List<(string Id, string Type, string Subtype, string[] Properties, string[] Others)>(){
                ("room_404", "bedroom", "doubled penetratin", new string[] { "extra-large", "XXL"}, new string[] { "mini-skirt", "ammm wardrobe", "mini refrigerator" }),
                ("room_406", "bedroom", "doubled penetratin", new string[] { "extra-large", "XXL"}, new string[] { "mini-skirt", "ammm wardrobe", "mini refrigerator" }),
                ("room_408", "bedroom", "doubled penetratin", new string[] { "extra-large", "XXL"}, new string[] { "mini-skirt", "ammm wardrobe", "mini refrigerator" }),

            };
            /*test data*/

            //return Ok(new[] { "room_404", "bedroom", "doubled penetratin", new string[] { "extra-large", "XXL" }, new string[] { "mini-skirt", "ammm wardrobe", "mini refrigerator" } }.ToList());
            //return Ok( new { "data" = 1, "data2" = 2, "data3" = 3 } );
            return Ok(
                new { Others = new string[] { "mini-skirt", "ammm wardrobe", "mini refrigerator", "tele-vision..." } }
            );
        }

        /* PENDING  - > OK */
        [HttpGet]
        [Route("api2/allpreservations")]
        public IHttpActionResult GetPreservations()
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
                new { Id = "room_404", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), User = "julcsa", Status = 1, Price=(1000)},
                new { Id = "room_406", StartDate = DateTime.Today.AddDays(4), EndDate = DateTime.Today.AddDays(7), User = "julcsa", Status = 0, Price=(5500)},
                new { Id = "room_408", StartDate = DateTime.Today.AddDays(5), EndDate = DateTime.Today.AddDays(6), User = "julcsa", Status = 0, Price=(750)},

                new { Id = "room_404", StartDate = DateTime.Now.AddDays(2), EndDate = DateTime.Now.AddDays(4), User = "mari", Status = 1, Price=(400)},
                //new { Id = "room_406", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(9), User = " ", Status = "Deleted", Price=500},
                new { Id = "room_406", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(9), User = "lali", Status = 1, Price=(3500)},
                new { Id = "room_408", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(10), User = "szaszi", Status = 0, Price=(2500)},
                new { Id = "room_409", StartDate = DateTime.Today.AddDays(2), EndDate = DateTime.Today.AddDays(10), User = "taszika a Mari Honaja", Status = 0, Price=(500)},
            });
        }


        [HttpPost]
        [Route("api2/editroom")]
        public IHttpActionResult EditRoom(/*RoomDTO room*/)
        {
            return Ok();
        }

        [HttpPost]
        [Route("api2/deleteroom")]
        public IHttpActionResult DeleteRoom([FromBody]String roomid)
        {
            return Ok(roomid);
        }

        [HttpPost]
        [Route("api2/editservice")]
        public IHttpActionResult EditService(int index)
        {
            return Ok();
        }

        /*nope*/
        [HttpPost]
        [Route("api2/editlanguage")]
        public IHttpActionResult EditLang(int index)
        {
            return Ok();
        }
        /*nope*/
        [HttpPost]
        [Route("api2/addservice")]
        public IHttpActionResult AddServ(string serv)
        {
            return Ok();
        }
        /*nope*/
        [HttpPost]
        [Route("api2/addlanguage")]
        public IHttpActionResult AddLang(string lang)
        {
            return Ok();
        }

        [HttpPost]
        [Route("api2/changebookingstatus")]
        public IHttpActionResult ChangeBookingStatus(/*ChangeDTO change*/)
        {
            // get a reservation id with roomid = ReservationStatus
            return Ok();
        }
    }
}

/*
    update + delete:
        room: roomModel;
        reservation: reservRoomModel;

     */
