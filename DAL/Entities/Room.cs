using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace DAL.Entities
{

    public class Room
    {
        public Room ( Type t)
        {
            Type = t;
        }
        public Room()
        {
           
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public Type Type { get; set; }
        public Subtype Subtype { get; set; }
        public double Price { get; set; }

        public virtual ICollection<RoomEquipment> RoomEquipment { get; set; }
        public virtual ICollection<RoomReservation> RoomReservations { get; set; }
        public virtual ICollection<RoomProperties> RoomProperties { get; set; }



    }
}
