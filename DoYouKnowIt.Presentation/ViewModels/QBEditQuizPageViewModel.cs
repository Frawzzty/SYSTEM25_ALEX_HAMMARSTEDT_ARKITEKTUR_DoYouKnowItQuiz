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

            if (quiz != null)
            {
                Quiz = quiz;
            }
            else
            {
                Quiz = new Quiz();
            }

            SaveQuizAsyncCommand = new Command(async () => await SaveQuizAsync());
        }

        ICommand SaveQuizAsyncCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private ObservableCollection<Question> _questions = new ObservableCollection<Question>();
        public ObservableCollection<Question> Questions { get { return _questions; } set { _questions = value; OnPropertyChanged(nameof(Questions)); } }

        private Quiz? _quiz;
        public Quiz? Quiz { get { return _quiz; } set { _quiz = value; OnPropertyChanged(nameof(Quiz)); } }


        public string QuizTitle { get { return Quiz.Title; } set { Quiz.Title = value; OnPropertyChanged(nameof(QuizTitle)); } }
        public string QuizDescription { get { return Quiz.Description; } set { Quiz.Description = value; OnPropertyChanged(nameof(QuizDescription)); } }
        public string QuizImageUrl { get { return Quiz.ImageUrl; } set { Quiz.ImageUrl = value; OnPropertyChanged(nameof(QuizImageUrl)); } }

        private async Task SaveQuizAsync()
        {
            //Update existing
            if (Quiz != null || Quiz.Id != 0)
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
    }
}
