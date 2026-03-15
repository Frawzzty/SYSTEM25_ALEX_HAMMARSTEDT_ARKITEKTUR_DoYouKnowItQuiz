using Domain.Entities.Models.DbModels;

namespace Domain.Entities.Models.Game
{
    public class QuizRoundResult
    {
        public QuizRoundResult(Question question, Answer selectedAnswer)
        {
            _question = question;
            _selectedAnswer = selectedAnswer;

            if (_question == null || selectedAnswer == null)
                return;

            LoadData();
        }

        //Calc vars
        private Question _question;
        private Answer _selectedAnswer;


        //Display vars
        public bool IsCorrect { get; set; }
        public int RoundScore { get; set; }

        public string QuestionText { get; set; }        = string.Empty;
        public string CorrectAnswersText { get; set; }  = string.Empty;
        public string SelectedAnswerText { get; set; }  = string.Empty;
        public string QuestionImageUrl { get; set; }    = string.Empty;



        //Methods
        private void LoadData()
        {
            if (_selectedAnswer.IsTrue) { IsCorrect = true; RoundScore++; }

            QuestionText = _question.QuestionText;

            CorrectAnswersText = string.Join(", ", _question.Answers.Where(x => x.IsTrue == true).Select(x => x.AnswerText).ToList());

            SelectedAnswerText = _selectedAnswer.AnswerText;

            QuestionImageUrl = _question.QuestionImageUrl;
        }
    }
}
