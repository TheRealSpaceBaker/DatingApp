using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dating_App.Models
{
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int QuizId { get; set; }
        [Ignore]
        public Quiz Quiz { get; set; }
        public int QuestionType { get; set; }
        [NotNull, Ignore]
        public List<string>? Options { get; set; }
    }
}
