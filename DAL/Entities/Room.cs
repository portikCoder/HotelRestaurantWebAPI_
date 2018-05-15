using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.Entities
{
    public class Room
    {
        [Key]
        public int id { get; set; }
        public String Type { get; set; }


        public virtual ICollection<RoomEquipment> RoomEquipment { get; set; }
        


    }
}
