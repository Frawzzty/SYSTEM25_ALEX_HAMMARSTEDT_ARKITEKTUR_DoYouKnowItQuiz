using Domain.Entities.Models.DbModels;
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

        private List<Question> _randomizedQuestionList = new List<Question>();


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

        //Runs one time
        public async Task LoadData()
        {
            //Check if QuizId is valid
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
                _randomizedQuestionList = Quiz.Questions.OrderBy(_ => Random.Shared.Next()).ToList(); //Shuffle question order
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
            if(_questionIndex >= _randomizedQuestionList.Count)
            {
                await Shell.Current.Navigation.PushAsync(new Views.Play.PlayResultQuizPage(_quizResult));
            }
            //Load next question and answers
            else
            {
                CurrentQuestion = _randomizedQuestionList[_questionIndex];
                CurrentAnswers = new ObservableCollection<Answer>(CurrentQuestion.Answers.OrderBy(x => Random.Shared.Next()).ToList()); //Randomize answer list order

                //Fail check, If no answers exists for the Question
                if (CurrentAnswers.Count == 0) 
                {
                    await Shell.Current.DisplayAlert("Error", $"The question: '{CurrentQuestion.QuestionText}' does not have any answers, please notify an Admin. Sending you back to select page", "OK");
                    await Shell.Current.GoToAsync("..");
                }
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

            //Add RoundResult - Validation and scoring handled inside Object
            _quizResult.AddRoundResult(new QuizRoundResult(CurrentQuestion, SelectedAnswer));

            //Load Next round
            _questionIndex++;
            LoadRound();

            //Deselect answer
            SelectedAnswer = null;
        }
        #endregion

    }
}
