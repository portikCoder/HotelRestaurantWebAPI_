using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelRestaurantAPI.Models
{
    public class RoomModel
    {
        public RoomModel()
        {
            PropertisList = new List<Properties>();
            EquipmentList = new List<Equipment>();
        }
        public Room room { get; set; }
        public List<Properties> PropertisList { get; set; }
        public List<Equipment> EquipmentList { get; set; }
    }
}