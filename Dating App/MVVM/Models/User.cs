using Dating_App.MVVM.Models.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dating_App.MVVM.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Required, Unique]
        public string? Username { get; set; }
        [Required, Unique]
        public string? CapitalizedUsername { get; set; }
        [Required, Unique]
        public string? Email { get; set; }
        [Required, Unique]
        public string? CapitalizedEmail { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required, Unique]
        public string? PhoneNumber { get; set; }
        [Ignore]
        public List<Message>? Matches { get; set; }
        [Ignore]
        public List<Quiz>? Quizzes { get; set; }
        public float? DistancePreference { get; set; }
        public int? LocationId { get; set; }
        [Ignore]
        public Location? Location { get; set; }
        public float? MatchScore { get; set; }

        public async Task<List<Message>> GetMatches()
        {
            var db = new DatingRegistry();
            var returned = await db.GetMatches(this);
            Matches = new List<Message>();
            Matches = returned;
            return returned;
        }
    }
}
