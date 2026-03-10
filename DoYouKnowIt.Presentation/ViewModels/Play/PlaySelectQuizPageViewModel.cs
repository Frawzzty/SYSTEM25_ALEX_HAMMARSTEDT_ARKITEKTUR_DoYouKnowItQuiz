using Domain.Entities.Models.DbModels;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Presentation.Views.Play;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Presentation.ViewModels.Play
{
    public class PlaySelectQuizPageViewModel : INotifyPropertyChanged
    {
        private IQuizService _quizService;
        public PlaySelectQuizPageViewModel(IQuizService quizService)
        {
            _quizService = quizService;
  
        }

        #region OnChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task OnSelectionChanged()
        {
            if(SelectedQuiz == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(PlayPlayQuizPage)}?QuizId={SelectedQuiz.Id}");

            //Reset selection
            SelectedQuiz = null;
        }
        #endregion
        
        private ObservableCollection<Quiz> _quizzes = new ObservableCollection<Quiz>();
        public ObservableCollection<Quiz> Quizzes { get { return _quizzes; } set { _quizzes = value; OnPropertyChanged(nameof(Quizzes)); } }

        //Keep track of original quizlist to avoid calling db again when filtereing
        private List<Quiz> _originalQuizList = new();

        private string _searchbarText = "";
        public string SearchbarText { 
            get { return _searchbarText; } 
            set { 
                _searchbarText = value; 
                OnPropertyChanged(nameof(SearchbarText));
                SearchQuizzes();
            } 
        }

        private Quiz _selectedQuiz;
        public Quiz SelectedQuiz { 
            get { return _selectedQuiz; } 
            set { _selectedQuiz = value; 
                OnPropertyChanged(nameof(SelectedQuiz));

                OnSelectionChanged();
            } 
        }


        //Load on Appearing in page codebehind
        public async Task LoadQuizzes()
        {
            Quizzes = new ObservableCollection<Quiz>(await _quizService.GetAllQuizzesAsync());
            _originalQuizList = Quizzes.ToList();
        }

        private void SearchQuizzes()
        {
            if (string.IsNullOrWhiteSpace(_searchbarText))
            {
                Quizzes = new ObservableCollection<Quiz>(_originalQuizList);
            }
            else
            {
                Quizzes = new ObservableCollection<Quiz>(_originalQuizList.Where(x => x.Title.ToLower().Contains(_searchbarText.ToLower())));
            }
                
        }

    }
}
