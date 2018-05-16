using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelRestaurantAPI.Models
{
    public class ReservationModel
    {
        public Reservation reservation { get; set; }
        public List<int> RoomId { get; set; }
    }
}