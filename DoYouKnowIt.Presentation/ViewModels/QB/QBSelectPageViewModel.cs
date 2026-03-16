using Domain.Entities.Interfaces;
using Domain.Entities.Models.DbModels;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Application.Services;
using DoYouKnowIt.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Presentation.ViewModels.QB
{
    public class QBSelectPageViewModel : INotifyPropertyChanged
    {
        IQuizService _quizService;
        public QBSelectPageViewModel(IQuizService quizService)
        {
            _quizService = quizService;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private ObservableCollection<Quiz> _quizzes = new ObservableCollection<Quiz>();
        public ObservableCollection<Quiz> Quizzes { get { return _quizzes; } set { _quizzes = value; OnPropertyChanged(nameof(Quizzes)); } }


        //Bound to CollectionVeiw.SelectedItem
        private Quiz _selectedQuiz;
        public Quiz SelectedQuiz 
        {
            get { return _selectedQuiz; }
            set
            {
                //If same selection? Remove?
                if (_selectedQuiz == value)
                    return;

                _selectedQuiz = value;
                OnPropertyChanged(nameof(SelectedQuiz));

                OnQuizSelected(value);
            }
        }


        private async Task OnQuizSelected(Quiz quiz)
        {
            if (quiz == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(Views.QB.QBEditQuizPage)}?QuizId={quiz.Id}");

            SelectedQuiz = null;
        }

        public async Task LoadData()
        {
            try
            {
                Quizzes = new ObservableCollection<Quiz>(await _quizService.GetAllQuizzesAsync());
            }
            catch (Exception ex)
            {
                Shell.Current.DisplayAlert("Error", $"Problem loading Quizzes, try refresh the page\nError message: {ex.Message}", "OK");
            }
            
        }
    }
}
