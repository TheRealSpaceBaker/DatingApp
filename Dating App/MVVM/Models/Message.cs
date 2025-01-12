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
        public int MatchId { get; set; }
        [Ignore]
        public User? Match { get; set; }
        public bool? IsSender { get; set; }
        public string? MessageContent { get; set; }
        public DateTime DateTimeSent { get; set; }
    }
}
