using Domain.Entities.Models.EntityFrameworkModels;
using Domain.Entities.Models.Game;
using DoYouKnowIt.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoYouKnowIt.Presentation.ViewModels.Play
{
    [QueryProperty(nameof(QuizId), "QuizId" )]
    public class PlayPlayQuizPageViewModel : INotifyPropertyChanged
    {
        IQuizService _quizService;
        public PlayPlayQuizPageViewModel(IQuizService quizService)
        {
            _quizService = quizService;
        }

        private QuizResult _quizResult;

        public ICommand NextQuestionCommand { get; set; }

        private int _questionIndex = 0;

        private int _quizId;
        public int QuizId { get { return _quizId; } set { _quizId = value; OnPropertyChanged(nameof(QuizId)); } }

        private Quiz _quiz;
        public Quiz Quiz { get { return _quiz; } set { _quiz = value; OnPropertyChanged(nameof(Quiz)); } }


        private Question _currentQuestion;
        public Question CurrentQuestion { get { return _currentQuestion; } set { _currentQuestion = value; OnPropertyChanged(nameof(CurrentQuestion)); } }

        private ObservableCollection<Answer> _currentAnswers = new();
        public ObservableCollection<Answer> CurrentAnswers { get { return _currentAnswers; } set { _currentAnswers = value; OnPropertyChanged(nameof(CurrentAnswers)); } }

        private Answer _selectedAnswer;
        public Answer SelectedAnswer {
            get { return _selectedAnswer; } 
            set { _selectedAnswer = value; 
                OnPropertyChanged(nameof(SelectedAnswer));
                OnSelectedAnswer();
            } 
        }
        public async Task LoadData()
        {
            //Check loading error
            if(QuizId == 0)
            {
                await Shell.Current.DisplayAlert("Error", "Going back...\nQuizId was 0", "OK");
                await Shell.Current.Navigation.PopAsync(); //Possible crash if triggered when page is still loading in
                return;
            }

            //Load Quiz
            await LoadQuiz();
            if (Quiz.Questions != null)
            {
                await LoadRound();
            }
            else
            {
                Shell.Current.DisplayAlert("Error", "No questions found", "OK");
            }
                
        }

        private async Task LoadQuiz()
        {
            Quiz = await _quizService.GetQuizAsync(QuizId);

            if (Quiz == null)
                return;

           _quizResult = new QuizResult(Quiz);
        }

        private async Task LoadRound()
        {
            //If no questions left. Go to result page
            if(_questionIndex >= Quiz.Questions.Count)
            {
                await Shell.Current.Navigation.PushAsync(new Views.Play.PlayResultQuizPage(_quizResult));
            }
            //Load next question and answers
            else
            {
                CurrentQuestion = Quiz.Questions.ToList()[_questionIndex];
                CurrentAnswers = new ObservableCollection<Answer>(CurrentQuestion.Answers);
            }
        }


        #region On Change
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs(propertyName));  
        }

        private void OnSelectedAnswer()
        {
            if (SelectedAnswer == null)
                return;

            //Validate answer
            QuizRoundResult quizRoundResult;
            List<string> trueAnswers = CurrentAnswers.Where(x => x.IsTrue == true).Select(x => x.AnswerText).ToList();
            if (SelectedAnswer.IsTrue)
            {
                quizRoundResult = new QuizRoundResult(
                    true, 
                    CurrentQuestion.QuestionText, 
                    trueAnswers, 
                    SelectedAnswer.AnswerText, 
                    1);
            }
            else
            {
                quizRoundResult = new QuizRoundResult(
                    false, 
                    CurrentQuestion.QuestionText, 
                    trueAnswers, 
                    SelectedAnswer.AnswerText, 
                    0);
            }
            
            //Add RoundResult
            _quizResult.AddRoundResult(quizRoundResult);

            //Load Next round
            _questionIndex++;
            LoadRound();

            //Deselect answer
            SelectedAnswer = null;
        }
        #endregion

    }
}
