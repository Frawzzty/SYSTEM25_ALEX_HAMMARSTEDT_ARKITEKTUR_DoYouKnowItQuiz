using Domain.Entities.Models.EntityFrameworkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models.Game
{
    public class QuizRoundResult
    {
        public QuizRoundResult(bool isCorrect, string questionText, List<string> correctAnswers, string userAnswerText, int roundScore)
        {
            IsCorrect = isCorrect;
            RoundScore = roundScore;

            QuestionText = questionText;
            CorrectAnswers = correctAnswers;
            UserAnswerText = userAnswerText;

            CorrectAnswersString = string.Join(", ", CorrectAnswers);
        }

        public bool IsCorrect { get; set; }
        public int RoundScore { get; set; }
        
        public string QuestionText { get; set; }
        public List<string> CorrectAnswers { get; set; }
        public string CorrectAnswersString { get; set; }
        public string UserAnswerText { get; set; }
    }
}
