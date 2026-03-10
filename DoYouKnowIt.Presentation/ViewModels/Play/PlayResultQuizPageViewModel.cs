using Domain.Entities.Models.EntityFrameworkModels;
using Domain.Entities.Models.Game;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoYouKnowIt.Presentation.ViewModels.Play
{
    public class PlayResultQuizPageViewModel : INotifyPropertyChanged
    {
        #region On Change
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public PlayResultQuizPageViewModel(QuizResult quizResult)
        {
            QuizResult = quizResult;
            RoundResults = new ObservableCollection<QuizRoundResult2>(QuizResult.RoundResult2);
            TotalScore = QuizResult.GetTotalScore();

            PopToRootCommand = new Command(async () => await Shell.Current.Navigation.PopToRootAsync());
        }

        public ICommand PopToRootCommand { get; set; }



        QuizResult _quizResult;
        public QuizResult QuizResult { get { return _quizResult; } set { _quizResult = value; OnPropertyChanged(nameof(QuizResult)); } }

        private ObservableCollection<QuizRoundResult2> _roundResults = new ObservableCollection<QuizRoundResult2>();
        public ObservableCollection<QuizRoundResult2> RoundResults { get { return _roundResults; } set { _roundResults = value; OnPropertyChanged(nameof(RoundResults)); } }

        private int _totalScore;
        public int TotalScore { get { return _totalScore; } set { _totalScore = value; OnPropertyChanged(nameof(TotalScore)); } }
    }
}
