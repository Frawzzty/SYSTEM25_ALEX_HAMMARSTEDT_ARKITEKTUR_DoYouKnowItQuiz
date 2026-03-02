using Domain.Entities.Interfaces;
using Domain.Entities.Models.EntityFrameworkModels;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Presentation.ViewModels
{
    internal class QBSelectPageViewModel : INotifyPropertyChanged
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

        public async Task LoadData()
        {
            Quizzes = new ObservableCollection<Quiz>(await _quizService.GetAllQuizzesAsync());
        }
    }
}
