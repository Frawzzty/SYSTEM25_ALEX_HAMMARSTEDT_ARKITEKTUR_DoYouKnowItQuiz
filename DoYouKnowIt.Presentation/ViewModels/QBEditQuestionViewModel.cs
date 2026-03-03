using Domain.Entities.Models.EntityFrameworkModels;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Application.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoYouKnowIt.Presentation.ViewModels
{
    internal class QBEditQuestionViewModel : INotifyPropertyChanged
    {
        private IQuestionService _questionService;
        private IAnswerService _answerService;
        public QBEditQuestionViewModel(int quizid, Question question)
        {
            _questionService = new QuestionService();
            _answerService = new AnswerService();

            LoadQuestion(question);
            Question.QuizId = quizid;
            LoadAnswersList();
            

            SaveQuestionCommand = new Command(async () => {     await SaveQuestionAsync();    await Shell.Current.Navigation.PopAsync(); });
            DeleteQuestionCommand = new Command(async () => {   await DeleteQuestionAsync();  await Shell.Current.Navigation.PopAsync(); });

        }

        private async Task LoadQuestion(Question question)
        {
            if (question == null)
            {
                _question = new();
            }
            //IF exists
            else
            {
                _question = question;
            }
        }

        private async Task LoadAnswersList()
        {


        }

        #region Commands
        public ICommand SaveQuestionCommand { get; set; }
        public ICommand DeleteQuestionCommand { get; set; }

        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        //Answer
        private ObservableCollection<Question> _answers = new ObservableCollection<Question>();
        public ObservableCollection<Question> Answers { get { return _answers; } set { _answers = value; OnPropertyChanged(nameof(Answers)); } }


        private Question _question;
        public Question Question { get { return _question; } set { _question = value; OnPropertyChanged(nameof(Question)); } }


        public string QuestionText {get { return _question.QuestionText; } set { _question.QuestionText = value; OnPropertyChanged(nameof(QuestionText)); } }
        public string QuestionImageUrl { get { return _question.QuestionImageUrl; } set { _question.QuestionImageUrl = value; OnPropertyChanged(nameof(QuestionImageUrl)); } }

        private async Task SaveQuestionAsync()
        {
            //Update existing
            if (Question != null || Question.Id > 0)
            {
                await _questionService.UpdateQuestionAsync(Question);
            }
            //Save new
            else
            {
                await _questionService.CreateQuestionAsync(Question);
            }
        }

        private async Task DeleteQuestionAsync()
        {
            if (Question != null || Question.Id > 0)
            {
                await _questionService.DeleteQuestionAsync(Question.Id);
            }
        }
    }
}
