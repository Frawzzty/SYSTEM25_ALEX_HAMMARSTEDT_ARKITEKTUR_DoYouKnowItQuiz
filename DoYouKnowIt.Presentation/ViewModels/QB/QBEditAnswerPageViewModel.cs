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
    [QueryProperty(nameof(QuestionId), "QuestionId")]
    [QueryProperty(nameof(AnswerId), "AnswerId")]
    public class QBEditAnswerPageViewModel : INotifyPropertyChanged
    {
        private IAnswerService _answerService;
        public bool IsInitialized = false;
        public QBEditAnswerPageViewModel(IAnswerService answerService)
        {
            _answerService = answerService;

            SaveAnswerCommand = new Command(async () => await SaveAnswer());
            DeleteAnswerCommand = new Command(async () => await DeleteAnswer());
        }

        public async Task LoadData()
        {
            //Get Answer, if new create new Answer() with correct QuestionId
            Answer = await _answerService.GetAnswerAsync(AnswerId) ?? new() { QuestionId = QuestionId };
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

        //Query Properties
        private int _questionId;
        public int QuestionId { get { return _questionId; } set { _questionId = value; OnPropertyChanged(nameof(QuestionId)); } }
        private int _answerId;
        public int AnswerId { get { return _answerId; } set { _answerId = value; OnPropertyChanged(nameof(AnswerId)); } }


        private Answer? _answer;
        public Answer? Answer { get { return _answer; } set { _answer = value; OnPropertyChanged(nameof(Answer)); } }

        private async Task SaveAnswer()
        {
            //Check inputs are valid
            if (string.IsNullOrWhiteSpace(Answer.AnswerText))
            {
                Shell.Current.DisplayAlert("Bad inputs", "Make sure inputs are not empty", "OK");
                return;
            }

            //Save new
            if (Answer != null && Answer.Id == 0)
            {
                await _answerService.CreateAnswernAsync(Answer);
            }
            //Update existing
            else
            {
                await _answerService.UpdateAnswerAsync(Answer);
            }

            await Shell.Current.Navigation.PopAsync();
        }

        private async Task DeleteAnswer()
        {
            //Delete quiz
            if (Answer != null && Answer.Id > 0)
            {
                await _answerService.DeleteAnswerAsync(Answer.Id);
            }

            await Shell.Current.Navigation.PopAsync();
        }
    }
}
