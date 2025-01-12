using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dating_App.MVVM.Models
{
    public class Message
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool IsMatch { get; set; }
        public int User1Id { get; set; }
        [Ignore]
        public User? User1 { get; set; }
        public int User2Id { get; set; }
        [Ignore]
        public User? User2 { get; set; }
        public bool? User1IsSender { get; set; }
        public string? MessageContent { get; set; }
        public DateTime DateTimeSent { get; set; }
    }
}
