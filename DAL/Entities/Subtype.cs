using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Subtype
    {
        public Subtype (string name)
        {
            this.name = name;
        }
        public Subtype() { }
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }

}

