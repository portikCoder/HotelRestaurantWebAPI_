using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Type
    {
        public Type (string name)
        {
            this.Name = name;
        }
        public Type()
        {
            
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
