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
    [Authorize]
    //[Route("api2/rooms")]
    public IHttpActionResult GetRooms(UserDTO user)
    {
      /* Get tthe lists of rooms from DB!!!! */
      List<Room> rooms = new List<Room>();

      /*test data*/
      /*test data*/

      return Ok(new[] {
                new { Id = "room_404", room_price = 500, Type = "bedroom", Subtype = "Single Bed", Properties = new string[] { "medium", "has a balcony" }, Others = new string[] { "air conditioning", "mini fridge" }},
                new { Id = "room_406", room_price = 600, Type = "bedroom", Subtype = "Three Beds", Properties = new string[] { "extra-large", "is on roof level" }, Others = new string[] { "air conditioning", "wardrobe", "mini fridge" } },
                new { Id = "room_408", room_price = 700, Type = "bedroom", Subtype = "Double Bed", Properties = new string[] { "medium" }, Others = new string[] { "television" }},
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
                new { Id = "room_404", StartDate = DateTime.Now.AddDays(0), EndDate = DateTime.Now.AddDays(2), Status = "Approved", Price=(1000)},
                new { Id = "room_406", StartDate = DateTime.Today.AddDays(4), EndDate = DateTime.Today.AddDays(7), Status = "Pending", Price=(5500)},
                new { Id = "room_408", StartDate = DateTime.Today.AddDays(5), EndDate = DateTime.Today.AddDays(6), Status = "Pending", Price=(750)},
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
  }
}
