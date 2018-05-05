using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSGameAPI.Entities
{
    public class Mine :Area
    {
        [Key]
        public int id { get; set; }
        private double mineCapacity;
        private double minedMaterial;

        public Mine(int terrainType, Tuple<int,int> position): base(terrainType, position)
        {

        }

        public double MineCapacity { get => mineCapacity; set => mineCapacity = value; }
        public double MinedMaterial { get => minedMaterial; set => minedMaterial = value; }
    }
}