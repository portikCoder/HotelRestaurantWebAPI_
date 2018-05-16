@@ -0,0 +1,95 @@
﻿using DAL;
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
    public class AdminController : ApiController
    {
        private HotelRestaurantDBContext DBContext = new HotelRestaurantDBContext();
        /*  For serving the subtype fields...
         * 
         */
        [HttpPost]
        [Route("api2/subtypes")]
        public IHttpActionResult GetSubtypes(UserDTO user)
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
            return Ok(
                new { Subtype = new[] { "singled penetratin", "doubled penetratin", "tripled penetratin" } }
            );
        }

        /*  For serving the extras fields...
         * 
         */
        [HttpPost]
        [Route("api2/extras")]
        public IHttpActionResult GetExtras(UserDTO user)
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

        /*  Route for recieving the new room data [from the admin! / or not!].
         * 
         */
        [HttpGet]
        [Route("api2/addnewroom")]
        public IHttpActionResult AddNewRoom(UserDTO user)
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
    }
}