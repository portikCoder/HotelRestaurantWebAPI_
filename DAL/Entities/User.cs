using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL.Entities
{
    public class User
    {
        [Key, Column(Order = 0x0)]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Room Room { get; set; }

        private int gatheredGold;
        private int gatheredMine;

        public int GatheredGold { get => gatheredGold; set => gatheredGold = value; }
        public int GatheredMine { get => gatheredMine; set => gatheredMine = value; }
        

        public User()
        {

        }
    }
}