using Domain.Entities.Interfaces;
using DoYouKnowIt.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Presentation.ViewModels.Test
{
    [QueryProperty(nameof(QuizId), "quizId")]
    public class QueryPropTestPageViewModel : INotifyPropertyChanged
    {
        private IQuizService _quizService;
        public QueryPropTestPageViewModel(IQuizService quizService)
        {
            _quizService = quizService;
        }


        private string _quizId;
        public string QuizId { get => _quizId; set { _quizId = value; OnPropertyChanged(nameof(QuizId)); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
