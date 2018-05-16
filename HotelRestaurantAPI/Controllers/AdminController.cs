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

    [HttpPost]
    [Route("api2/allpreservations")]
    public IHttpActionResult GetPreservations(UserDTO user)
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
                new { Id = "room_404", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), User = "julcsa", Status = "Approved", Price=(1000)},
                new { Id = "room_406", StartDate = DateTime.Today.AddDays(4), EndDate = DateTime.Today.AddDays(7), User = "julcsa", Status = "Pending", Price=(5500)},
                new { Id = "room_408", StartDate = DateTime.Today.AddDays(5), EndDate = DateTime.Today.AddDays(6), User = "julcsa", Status = "Pending", Price=(750)},

                new { Id = "room_404", StartDate = DateTime.Now.AddDays(2), EndDate = DateTime.Now.AddDays(4), User = "mari", Status = "Approved", Price=(400)},
                //new { Id = "room_406", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(9), User = " ", Status = "Deleted", Price=500},
                new { Id = "room_406", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(9), User = "lali", Status = "Approved", Price=(3500)},
                new { Id = "room_408", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(10), User = "szaszi", Status = "Pending", Price=(2500)},
                new { Id = "room_409", StartDate = DateTime.Today.AddDays(2), EndDate = DateTime.Today.AddDays(10), User = "taszika a Mari Honaja", Status = "Pending", Price=(500)},
            });
    }
  }
}