using Domain.Entities.Models.EntityFrameworkModels;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoYouKnowIt.Presentation.ViewModels.QB
{
    internal class QBEditAnswerPageViewModel : INotifyPropertyChanged
    {
        IAnswerService _answerService;
        public QBEditAnswerPageViewModel(int questionId, Answer answer)
        {
            _answerService = new AnswerService();

            if (answer != null)
            {
                _answer = answer;
                LoadAnswerInputs();
            }
            else
            {
                _answer = new();
                _answer.QuestionId = questionId; //If new question set correct QuizId
            }

            SaveAnswerCommand = new Command(async () => await SaveAnswer());
            DeleteAnswerCommand = new Command(async () => await DeleteAnswer());
        }

        #region Commands
        public ICommand SaveAnswerCommand { get; set; }
        public ICommand DeleteAnswerCommand { get; set; }
        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        private Answer? _answer;
        private string _answerText;
        private bool _isTrue;
        public string AnswerText { get { return _answerText; } set { _answerText = value; OnPropertyChanged(nameof(AnswerText)); } }
        public bool IsTrue { get { return _isTrue; } set { _isTrue = value; OnPropertyChanged(nameof(IsTrue)); } }



        private void LoadAnswerInputs()
        {
            AnswerText = _answer.AnswerText;
            IsTrue = _answer.IsTrue;
        }

        private void SetAnswer()
        {
            _answer.AnswerText = AnswerText;
            _answer.IsTrue = IsTrue;
        }

        private async Task SaveAnswer()
        {
            //Check inputs are valid
            if (string.IsNullOrWhiteSpace(AnswerText))
            {
                Shell.Current.DisplayAlert("Bad inputs", "Make sure inputs are not empty", "OK");
                return;
            }

            //Set quiz properties to entry bound inputs
            SetAnswer();

            //Save new
            if (_answer != null && _answer.Id == 0)
            {
                await _answerService.CreateAnswernAsync(_answer);
            }
            //Update existing
            else
            {
                await _answerService.UpdateAnswerAsync(_answer);
            }

            await Shell.Current.Navigation.PopAsync();
        }

        private async Task DeleteAnswer()
        {
            //Delete quiz
            if (_answer != null && _answer.Id > 0)
            {
                await _answerService.DeleteAnswerAsync(_answer.Id);
            }

            await Shell.Current.Navigation.PopAsync();
        }
    }
}
