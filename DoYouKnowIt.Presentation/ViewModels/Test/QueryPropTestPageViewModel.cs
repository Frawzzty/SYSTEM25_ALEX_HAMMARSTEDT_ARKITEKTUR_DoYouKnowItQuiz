using Domain.Entities.Interfaces;
using Domain.Entities.Models.EntityFrameworkModels;
using DoYouKnowIt.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoYouKnowIt.Presentation.ViewModels.Test
{

    [QueryProperty(nameof(QuizId), "quizId")]
    public class QueryPropTestPageViewModel : INotifyPropertyChanged
    {
        private IQuizService _quizService;
        
        public QueryPropTestPageViewModel(IQuizService quizService)
        {
            _quizService = quizService;

            SaveQuizCommand = new Command(async () => { await SaveQuiz(); });
        }

        public ICommand SaveQuizCommand { get; set; }


        private int _quizId;
        public int  QuizId 
        {
            get => _quizId; 
            set { _quizId = value; OnPropertyChanged(nameof(QuizId)); } 
        }


        private Quiz? _quiz;
        public Quiz? Quiz 
        { 
            get => _quiz; 
            set { _quiz = value; 
                OnPropertyChanged(nameof(Quiz));
                //OnPropertyChanged(nameof(QuizTitle));
                //OnPropertyChanged(nameof(QuizDescription));
                //OnPropertyChanged(nameof(QuizImageUrl));
            } 
        }

        //public string? QuizTitle        { get => _quiz?.Title ;         set { _quiz.Title = value;          OnPropertyChanged(nameof(QuizTitle)); } }
        //public string? QuizDescription   { get => _quiz?.Description;    set { _quiz.Description = value;    OnPropertyChanged(nameof(QuizDescription)); } }
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

        private async Task SaveQuiz()
        {
            if (Quiz == null)
                return;

            //Save New
            if (Quiz.Id == null || Quiz.Id == 0)
            {
                await _quizService.CreateQuizAsync(Quiz);
            }
            //Update Existing
            else
            {
                await _quizService.UpdateQuizAsync(Quiz);
            }

            await Shell.Current.Navigation.PopAsync();
        }

    }
}
