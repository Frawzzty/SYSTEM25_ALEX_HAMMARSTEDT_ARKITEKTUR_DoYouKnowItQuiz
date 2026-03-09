using Domain.Entities.Models.EntityFrameworkModels;
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
            //NextQuestionCommand = new Command(() => { _questionIndex++; LoadCurrentRound(); });
        }

        public ICommand NextQuestionCommand { get; set; }

        private int _questionIndex = 0;

        private int _totalScore = 0;
        public int TotalScore { get { return _totalScore; } set { _totalScore = value; OnPropertyChanged(nameof(TotalScore)); } }


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
            if (QuizId != 0) 
            {
                await LoadQuiz();

                if (Quiz.Questions != null)
                {
                    LoadRound();
                }
                    
                else
                    Shell.Current.DisplayAlert("Error", "No questions found", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Going back...\nQuizId was 0", "OK");
                await Shell.Current.Navigation.PopAsync(); //Possible crash if triggered when page is still loading in
            }
            
        }

        private async Task LoadQuiz()
        {
            Quiz = await _quizService.GetQuizAsync(QuizId);
        }

        private void LoadRound()
        {
            
            if(_questionIndex >= Quiz.Questions.Count)
            {
                Shell.Current.DisplayAlert("Out of range", "Send user to Result page", "I will add this function");
                CurrentAnswers = null;
                CurrentQuestion = null;
            }
            else
            {
                //Load question
                CurrentQuestion = Quiz.Questions.ToList()[_questionIndex];
                //Load answers
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
            if(SelectedAnswer.IsTrue)
            {
                TotalScore++;
            }

            _questionIndex++;
            LoadRound();

            //Deselect answer
            SelectedAnswer = null;
        }
        #endregion

    }
}
