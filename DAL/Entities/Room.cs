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


        public virtual ICollection<RoomEquipment> RoomEquipment { get; set; }
        


    }
}
