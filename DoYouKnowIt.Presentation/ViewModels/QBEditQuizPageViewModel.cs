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
        IQuizService _quizService;

        public QBEditQuizPageViewModel(Quiz quiz)
        {
            _quizService = new QuizService();

            LoadQuiz(quiz); //Get by ID instead?

            SaveQuizAsyncCommand =      new Command(async () => await SaveQuizAsync());
            DeleteQuizCommand =         new Command(async () => {await DeleteQuizAsnyc(); await Shell.Current.Navigation.PopAsync();});
            EditQuestionAsyncCommand =  new Command(async () => await Shell.Current.Navigation.PushAsync(new Views.QB.QBEditQuestionPage(null)));
        }

        #region Commands
        public ICommand SaveQuizAsyncCommand { get; set; }
        public ICommand DeleteQuizCommand { get; set; }
        public ICommand EditQuestionAsyncCommand { get; set; }
        
        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        //QUESTION
        private ObservableCollection<Question> _questions = new ObservableCollection<Question>();
        public ObservableCollection<Question> Questions { get { return _questions; } set { _questions = value; OnPropertyChanged(nameof(Questions)); } }

        //QUIZ
        private Quiz _quiz;
        public Quiz Quiz { get { return _quiz; } set { _quiz = value; OnPropertyChanged(nameof(Quiz)); } }

        public string QuizTitle         { get { return Quiz.Title; }        set { Quiz.Title = value;       OnPropertyChanged(nameof(QuizTitle)); } }
        public string QuizDescription   { get { return Quiz.Description; }  set { Quiz.Description = value; OnPropertyChanged(nameof(QuizDescription)); } }
        public string QuizImageUrl      { get { return Quiz.ImageUrl; }     set { Quiz.ImageUrl = value;    OnPropertyChanged(nameof(QuizImageUrl)); } }



        #region Methods
        private async Task SaveQuizAsync()
        {
            //Update existing
            if (Quiz != null || Quiz.Id > 0)
            {
                await _quizService.UpdateQuizAsync(Quiz);
            }
            //Save new
            else
            {
                await _quizService.CreateQuizAsync(Quiz);
            }

            await Shell.Current.Navigation.PopAsync();
        }

        private async Task DeleteQuizAsnyc()
        {
            if (Quiz != null || Quiz.Id > 0)
            {
                await _quizService.DeleteQuizAsync(Quiz.Id);
            }
        }


        private void LoadQuiz(Quiz quiz)
        {
            if (quiz != null)
            {
                Quiz = quiz;
                Questions = new ObservableCollection<Question>(Quiz.Questions);
            }

            else
            {
                Quiz = new Quiz();
            }
        }

        public async Task LoadQuestions()
        {
            if(Quiz.Id != null)
            {
                var data = await _quizService.GetQuizAsync(Quiz.Id);
                Questions = new ObservableCollection<Question>(data.Questions);
                Console.WriteLine();
            }

        }
        #endregion
    }
}
