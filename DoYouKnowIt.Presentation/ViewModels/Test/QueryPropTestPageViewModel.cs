using Domain.Entities.Interfaces;
using Domain.Entities.Models.EntityFrameworkModels;
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


        private int _quizId;
        public int  QuizId 
        {
            get => _quizId; 
            set { _quizId = value; OnPropertyChanged(nameof(QuizId)); 
            } 
        }


        private Quiz? _quiz;
        public Quiz? Quiz 
        { 
            get => _quiz; 
            set { _quiz = value; 
                OnPropertyChanged(nameof(Quiz));
                //OnPropertyChanged(nameof(QuizTitle));
                //OnPropertyChanged(nameof(QuizDesciption));
                //OnPropertyChanged(nameof(QuizImageUrl));
            } 
        }

        //public string? QuizTitle        { get => _quiz?.Title ;         set { _quiz.Title = value;          OnPropertyChanged(nameof(QuizTitle)); } }
        //public string? QuizDesciption   { get => _quiz?.Description;    set { _quiz.Description = value;    OnPropertyChanged(nameof(QuizDesciption)); } }
        //public string? QuizImageUrl     { get => _quiz?.ImageUrl;       set { _quiz.ImageUrl = value;       OnPropertyChanged(nameof(QuizImageUrl)); } }

        #region Property Changed
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public async void LoadQuiz()
        {
            Quiz = await _quizService.GetQuizAsync(QuizId) ?? new Quiz();
        }
    }
}
