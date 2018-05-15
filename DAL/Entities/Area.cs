using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.Entities
{
    public class Area
    {
        [Key]
        public int Id {get; set; }
        private Tuple<int, int> position;
        public int X { get; set; }
        public int Y { get; set; }
        private int terrainType;
        //private String mineDenomination; // megnevezes

        public Area()
        {
            // idasbled constructor
        }

        public Area(int terrainType, Tuple<int, int> position)
        {
            this.terrainType = terrainType;
            this.position = position;
            this.X = this.position.Item1;
            this.Y = this.position.Item2;
        }

        public int TerrainType { get => terrainType; set => terrainType = value; }
    }
}