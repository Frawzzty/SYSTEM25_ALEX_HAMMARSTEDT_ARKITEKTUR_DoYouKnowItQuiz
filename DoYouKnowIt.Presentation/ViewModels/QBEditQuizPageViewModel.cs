using Domain.Entities.Models.EntityFrameworkModels;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Application.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoYouKnowIt.Presentation.ViewModels
{
    internal class QBEditQuizPageViewModel : INotifyPropertyChanged
    {
        private IQuizService _quizService;

        public QBEditQuizPageViewModel(Quiz quiz)
        {
            _quizService = new QuizService();

            //Load quiz
            if(quiz != null)
            {
                _quiz = quiz;
                LoadQuizInputs();
            }
            else
            {
                _quiz = new Quiz();
            }


            //Commands
            SaveQuizCommand = new Command(async () => await SaveQuiz());
            DeleteQuizCommand = new Command(async () => await DeleteQuiz());
        }


        #region Commands
        public ICommand SaveQuizCommand { get; set; }
        public ICommand DeleteQuizCommand { get; set; }
        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        private Question _selectedQuestion;
        public Question SelectedQuestion //Bind to CollectionView.SelectedItem
        {
            get { return _selectedQuestion; }
            set
            {
                //If same selection? Remove?
                if (_selectedQuestion == value)
                    return;

                _selectedQuestion = value;
                OnPropertyChanged(nameof(SelectedQuestion));

                OnQuizSelected(value);
            }
        }


        private Quiz? _quiz;

        private string _quizTitle;
        private string _quizDescription;
        private string _quizImageUrl;
        public string QuizTitle         { get { return _quizTitle; }        set { _quizTitle = value;       OnPropertyChanged(nameof(QuizTitle)); } }
        public string QuizDescription   { get { return _quizDescription; }  set { _quizDescription = value; OnPropertyChanged(nameof(QuizDescription)); } }
        public string QuizImageUrl      { get { return _quizImageUrl; }     set { _quizImageUrl = value;    OnPropertyChanged(nameof(QuizImageUrl)); } }


        private ObservableCollection<Question> _questions = new();
        public ObservableCollection<Question> Questions { get { return _questions; } set { _questions = value; OnPropertyChanged(nameof(Questions)); } }

        #region Methods

        private void LoadQuizInputs()
        {
            QuizTitle = _quiz.Title;
            QuizDescription = _quiz.Description;
            QuizImageUrl = _quiz.ImageUrl;
        }

        private void SetQuiz()
        {
            _quiz.Title = QuizTitle;
            _quiz.Description = QuizDescription;
            _quiz.ImageUrl = QuizImageUrl;
        }

        public async Task RefreshQuestionList()
        {
            //CHeck its not a new quiz
            if (_quiz == null || _quiz.Id == 0)
                return;

            var questionData = await _quizService.GetQuizAsync(_quiz.Id);

            if (questionData == null)
                return;

            Questions.Clear();
            foreach(var question in questionData.Questions)
            {
                Questions.Add(question);
            }
            
        }

        private async Task SaveQuiz()
        {
            //Check inputs are valid
            if (string.IsNullOrWhiteSpace(QuizTitle) && string.IsNullOrWhiteSpace(QuizDescription) && string.IsNullOrWhiteSpace(QuizImageUrl))
            {
                Shell.Current.DisplayAlert("Bad inputs","Make sure inputs are not empty","OK");
                return;
            }

            //Set quiz properties to entry bound inputs
            SetQuiz();

            //Save new
            if (_quiz != null && _quiz.Id == 0)
            {
                await _quizService.CreateQuizAsync(_quiz);
            }
            //Update existing
            else
            {
                await _quizService.UpdateQuizAsync(_quiz);
            }

            await Shell.Current.Navigation.PopAsync();
            
        }

        private async Task DeleteQuiz()
        {
            //Delete quiz
            if (_quiz != null && _quiz.Id > 0)
            {
                await _quizService.DeleteQuizAsync(_quiz.Id);
            }

            await Shell.Current.Navigation.PopAsync();
        }


        private async Task OnQuizSelected(Question question)
        {
            if (question == null)
                return;

            //await Shell.Current.Navigation.PushAsync(new Views.QB.QBEditQuestionPage(Quiz.Id, question));

            SelectedQuestion = null;
        }
        #endregion
    }
}
