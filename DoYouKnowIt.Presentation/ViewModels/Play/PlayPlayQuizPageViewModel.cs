using Domain.Entities.Models.EntityFrameworkModels;
using DoYouKnowIt.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private int _quizId;
        public int QuizId { get { return _quizId; } set { _quizId = value; OnPropertyChanged(nameof(QuizId)); } }

        private Quiz _quiz;
        public Quiz Quiz { get { return _quiz; } set { _quiz = value; OnPropertyChanged(nameof(Quiz)); } }

        public async Task LoadData()
        {
            if (QuizId != 0) 
            {
                Quiz = await _quizService.GetQuizAsync(QuizId);
            }
            
        }

        #region On Change
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs(propertyName));  
        }
        #endregion


    }


}
