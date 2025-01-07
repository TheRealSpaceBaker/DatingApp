using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dating_App.Models
{
    public class Quiz
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        [Ignore]
        public List<Question> Questions { get; set; }
    }
}
