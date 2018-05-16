using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.Entities
{

    public class Room
    {
        public Room ( String t)
        {
            Type = t;
        }
        public Room()
        {
           
        }
        [Key]
        public int Id { get; set; }
        public String Type { get; set; }

        //s
        public virtual ICollection<RoomEquipment> RoomEquipment { get; set; }
        public virtual ICollection<RoomReservation> RoomReservations { get; set; }



    }
}
