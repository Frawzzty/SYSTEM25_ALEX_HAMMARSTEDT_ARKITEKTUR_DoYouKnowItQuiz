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

namespace DoYouKnowIt.Presentation.ViewModels.QB
{
    internal class QBEditQuestionPageViewModel : INotifyPropertyChanged
    {
        IQuestionService _questionService;
        IAnswerService _answerService;
        public QBEditQuestionPageViewModel(int quizId, Question question)
        {
            _questionService = new QuestionService();
            _answerService = new AnswerService();

            if (question != null)
            {
                _question = question;
                LoadQuestionInputs();
            }
            else
            {
                _question = new();
                _question.QuizId = quizId; //If new question set correct QuizId
            }

            
            SaveQuestionCommand = new Command(async () => await SaveQuestion());
            DeleteQuestionCommand = new Command(async () => await DeleteQuestion());
            AddNewAnswerCommand = new Command(async () => await Shell.Current.Navigation.PushAsync(new Views.QB.QBEditAnswerPage(_question.Id, null)));
        }

        #region Commands
        public ICommand AddNewAnswerCommand { get; set; }
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


        private Question? _question;

        private string _questionText;
        private string _questionImageUrl;
        public string QuestionText { get { return _questionText; } set { _questionText = value; OnPropertyChanged(nameof(QuestionText)); } }
        public string QuestionImageUrl { get { return _questionImageUrl; } set { _questionImageUrl = value; OnPropertyChanged(nameof(QuestionImageUrl)); } }

        private ObservableCollection<Answer> _answers = new();
        public ObservableCollection<Answer> Answers { get { return _answers; } set { _answers = value; OnPropertyChanged(nameof(Answers)); } }

        private Answer _selectedAnswer;
        public Answer SelectedAnswer 
        { 
            get { return _selectedAnswer; } 
            set 
            { 
                _selectedAnswer = value; 
                OnPropertyChanged(nameof(SelectedAnswer));

                OnQuestionSelected(SelectedAnswer);
            } 
        }


        private async Task OnQuestionSelected(Answer question)
        {
            if (question == null)
                return;

            await Shell.Current.Navigation.PushAsync(new Views.QB.QBEditAnswerPage(_question.Id, SelectedAnswer));

            SelectedAnswer = null;
        }

        public async Task RefreshQuestionList()
        {
            //CHeck its not a new quiz
            if (_question == null || _question.Id == 0)
                return;

            var answerData = await _questionService.GetQuestionAsync(_question.Id);

            if (answerData == null)
                return;

            Answers.Clear();
            foreach (var question in answerData.Answers)
            {
                Answers.Add(question);
            }

        }

        private void LoadQuestionInputs()
        {
            QuestionText = _question.QuestionText;
            QuestionImageUrl = _question.QuestionImageUrl;
        }

        private void SetQuestion()
        {
            _question.QuestionText = QuestionText;
            _question.QuestionImageUrl = QuestionImageUrl;
        }

        private async Task SaveQuestion()
        {
            //Check inputs are valid
            if (string.IsNullOrWhiteSpace(QuestionText) || string.IsNullOrWhiteSpace(QuestionImageUrl))
            {
                Shell.Current.DisplayAlert("Bad inputs", "Make sure inputs are not empty", "OK");
                return;
            }

            //Set quiz properties to entry bound inputs
            SetQuestion();

            //Save new
            if (_question != null && _question.Id == 0)
            {
                await _questionService.CreateQuestionAsync(_question);
            }
            //Update existing
            else
            {
                await _questionService.UpdateQuestionAsync(_question);
            }

            await Shell.Current.Navigation.PopAsync();
        }

        private async Task DeleteQuestion()
        {
            //Delete quiz
            if (_question != null && _question.Id > 0)
            {
                await _questionService.DeleteQuestionAsync(_question.Id);
            }

            await Shell.Current.Navigation.PopAsync();
        }


    }
}
