using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dating_App.Models
{
    public class Message
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int SenderId { get; set; }
        [Ignore]
        public User? Sender { get; set; }
        public int ReceiverId { get; set; }
        [Ignore]
        public User? Receiver { get; set; }
    }
}
