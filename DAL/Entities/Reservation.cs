using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Reservation
    {
        [Key]
        public int Id{get; set;}
        public DateTime createReservation { get; set; }
        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }
        public Double price { get; set; }
        public int status { get; set; }

        public virtual ICollection<RoomReservation> RoomReservations { get; set; }



    }
}
