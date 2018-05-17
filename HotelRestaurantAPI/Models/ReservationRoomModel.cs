using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelRestaurantAPI.Models
{
    public class ReservationRoomModel
    {
        public int Id { get; set; }
        public DateTime createReservation { get; set; }
        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }
        public Double price { get; set; }
        public int status { get; set; }
        public int roomId { get; set; }
    }
}