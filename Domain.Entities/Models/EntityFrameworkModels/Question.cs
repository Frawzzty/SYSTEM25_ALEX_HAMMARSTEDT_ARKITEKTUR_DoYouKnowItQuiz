using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models.EntityFrameworkModels
{
    public class Question
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public string QuestionText { get; set; }
        public string QuestionImageUrl { get; set; }
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
