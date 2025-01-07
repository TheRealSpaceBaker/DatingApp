using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dating_App.Models
{
    public class QuizAnswer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Ignore]
        public User? User { get; set; }
        public int QuestionId { get; set; }
        [Ignore]
        public Question? Question { get; set; }
        [AllowNull]
        public int? SelectedOptionIndex { get; set; }
        [AllowNull]
        public string? OpenEndedResponse { get; set; }
    }
}
