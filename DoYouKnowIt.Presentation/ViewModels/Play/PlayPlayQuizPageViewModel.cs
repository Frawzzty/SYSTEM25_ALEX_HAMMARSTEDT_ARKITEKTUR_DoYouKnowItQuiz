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
        private int _quizId;
        public int QuizId { get { return _quizId; } set { _quizId = value; } }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs(propertyName));  
        }
    }

  
}
