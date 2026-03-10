using Domain.Entities.Models.EntityFrameworkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models.Game
{
    public class QuizResult
    {
        public QuizResult(Quiz quiz)
        {
            Quiz = quiz;
        }

        public Quiz Quiz { get; set; }
        public List<QuizRoundResult> RoundResult { get; set; } = new();

        public void AddRoundResult(QuizRoundResult roundResult)
        {
            if (roundResult == null)
                return;

            RoundResult.Add(roundResult);
        }

        public int GetTotalScore()
        {
            int myScore = 0;
            foreach (var roundResult in RoundResult)
            {
                myScore += roundResult.RoundScore;
            }

            return myScore;
        }

   
    }
}
