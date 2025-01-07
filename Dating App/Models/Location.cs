using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dating_App.Models
{
    public class Location
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Ignore]
        public User? User { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}
