using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class RoomReservation
    {
        [Key]
        public int RoomId { get; set; }
        public int ReservationId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
        [ForeignKey("ReservationId")]
        public virtual Reservation Reservation { get; set; }

       
    }
}
