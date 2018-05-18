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
                ("room_404", "bedroom", "Single Bed", new string[] { "medium", "has a balcony" }, new string[] { "air conditioning", "mini fridge" }),
                ("room_406", "bedroom", "Three Beds", new string[] { "extra-large", "is on roof level" }, new string[] { "air conditioning", "wardrobe", "mini fridge" }),
                ("room_408", "bedroom", "Double Bed", new string[] { "medium" }, new string[] { "television" }),

            };
      /*test data*/

      //return Ok(new[] { "room_404", "bedroom", "doubled penetratin", new string[] { "extra-large", "XXL" }, new string[] { "air conditioning", "wardrobe", "mini fridge" } }.ToList());
      //return Ok( new { "data" = 1, "data2" = 2, "data3" = 3 } );
      return Ok(
          new { Subtype = new[] { "Single Bed", "Double Bed", "Three Beds" } }
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
                ("room_404", "bedroom", "Single Bed", new string[] { "medium", "has a balcony" }, new string[] { "air conditioning", "mini fridge" }),
                ("room_406", "bedroom", "Three Beds", new string[] { "extra-large", "is on roof level" }, new string[] { "air conditioning", "wardrobe", "mini fridge" }),
                ("room_408", "bedroom", "Double Bed", new string[] { "medium" }, new string[] { "television" }),

            };
      /*test data*/

      //return Ok(new[] { "room_404", "bedroom", "doubled penetratin", new string[] { "extra-large", "XXL" }, new string[] { "air conditioning", "wardrobe", "mini fridge" } }.ToList());
      //return Ok( new { "data" = 1, "data2" = 2, "data3" = 3 } );
      return Ok(
          new { Others = new string[] { "air conditioning", "wardrobe", "mini fridge", "television" } }
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
                ("room_404", "bedroom", "Single Bed", new string[] { "medium", "has a balcony" }, new string[] { "air conditioning", "mini fridge" }),
                ("room_406", "bedroom", "Three Beds", new string[] { "extra-large", "is on roof level" }, new string[] { "air conditioning", "wardrobe", "mini fridge" }),
                ("room_408", "bedroom", "Double Bed", new string[] { "medium" }, new string[] { "television" }),

            };
      /*test data*/

      //return Ok(new[] { "room_404", "bedroom", "doubled penetratin", new string[] { "extra-large", "XXL" }, new string[] { "air conditioning", "wardrobe", "mini fridge" } }.ToList());
      //return Ok( new { "data" = 1, "data2" = 2, "data3" = 3 } );
      return Ok(
          new { Others = new string[] { "air conditioning", "wardrobe", "mini fridge", "tele-vision..." } }
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
                ("room_404", "bedroom", "Single Bed", new string[] { "medium", "has a balcony" }, new string[] { "air conditioning", "mini fridge" }),
                ("room_406", "bedroom", "Three Beds", new string[] { "extra-large", "is on roof level" }, new string[] { "air conditioning", "wardrobe", "mini fridge" }),
                ("room_408", "bedroom", "Double Bed", new string[] { "medium" }, new string[] { "television" }),

            };
      /*test data*/

      //return Ok(new[] { "room_404", "bedroom", "doubled penetratin", new string[] { "extra-large", "XXL" }, new string[] { "air conditioning", "wardrobe", "mini fridge" } }.ToList());
      //return Ok( new { "data" = 1, "data2" = 2, "data3" = 3 } );
      return Ok(new[] {
                new { Id = "room_404", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2), User = "Kovacs Julia", Status = 1, Price=(1000)},
                new { Id = "room_406", StartDate = DateTime.Today.AddDays(4), EndDate = DateTime.Today.AddDays(7), User = "Kovacs Julia", Status = 0, Price=(5500)},
                new { Id = "room_408", StartDate = DateTime.Today.AddDays(5), EndDate = DateTime.Today.AddDays(6), User = "Kovacs Julia", Status = 0, Price=(750)},

                new { Id = "room_404", StartDate = DateTime.Now.AddDays(2), EndDate = DateTime.Now.AddDays(4), User = "Hajdu Maria", Status = -1, Price=(400)},
                //new { Id = "room_406", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(9), User = " ", Status = "Deleted", Price=500},
                new { Id = "room_406", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(9), User = "Nagy Laszlo", Status = 1, Price=(3500)},
                new { Id = "room_408", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(10), User = "Szasz Erno", Status = 0, Price=(2500)},
                new { Id = "room_409", StartDate = DateTime.Today.AddDays(2), EndDate = DateTime.Today.AddDays(10), User = "Takacs Denes", Status = 0, Price=(500)},
            });
    }
  }
}