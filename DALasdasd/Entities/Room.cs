using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSGameAPI.Entities
{
    public class Room
    {
        [Key]
        // about room
        public int id { get; set; }
        private Tuple<int, int> location;
        public int X { get; set; }
        public int Y { get; set; }
        private int neighbours;

        private Room()
        {
            // do nothing
        }
        public Room(Tuple<int, int> location)
        {
            this.Location = location;
            this.X = Location.Item1;
            this.Y = Location.Item2;
        }

        public Tuple<int, int> Location { get => location; set => location = value; }
        public int Neighboors { get => neighbours; set => neighbours = value; } // missing the set RRESTRICTIONS, such as it can only be 1234
    }
}
