using Domain.Entities.Models.EntityFrameworkModels;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Application.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    [QueryProperty(nameof(QuizId), "QuizId")]
    public class QBEditQuizPageViewModel : INotifyPropertyChanged
    {
        private IQuizService _quizService;
        //private IQuestionService _questionService; //Not used atm

        public QBEditQuizPageViewModel(IQuizService quizService)
        {
            _quizService = quizService;
            //_questionService = new QuestionService();


            //Commands
            AddNewQuestionCommand = new Command(async () => { await Shell.Current.Navigation.PushAsync(new Views.QB.QBEditQuestionPage(_quiz.Id, null)); });
            SaveQuizCommand = new Command(async () =>       { await SaveQuiz(); });
            DeleteQuizCommand = new Command(async () =>     { await DeleteQuiz(); });
        }

        private int _quizId;
        public int QuizId { get { return _quizId; } set { _quizId = value; OnPropertyChanged(nameof(QuizId)); } }

        #region Commands
        public ICommand AddNewQuestionCommand { get; set; }
        public ICommand SaveQuizCommand { get; set; }
        public ICommand DeleteQuizCommand { get; set; }
        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        private Question _selectedQuestion;
        public Question SelectedQuestion //Bind to CollectionView.SelectedItem
        {
            get { return _selectedQuestion; }
            set
            {
                //If same selection? Remove?
                if (_selectedQuestion == value)
                    return;

                _selectedQuestion = value;
                OnPropertyChanged(nameof(SelectedQuestion));

                OnQuestionSelected(value);
            }
        }


        private Quiz? _quiz;
        public Quiz? Quiz
        {
            get { return _quiz; } set { _quiz = value; OnPropertyChanged(nameof(Quiz)); }
        }

        public async Task InitializeData()
        {
            //Get quiz if new create new Quiz()
            Quiz = await _quizService.GetQuizAsync(QuizId) ?? new();
            await RefreshQuestionList();
        }

        private ObservableCollection<Question> _questions = new();
        public ObservableCollection<Question> Questions { get { return _questions; } set { _questions = value; OnPropertyChanged(nameof(Questions)); } }

        #region Methods


        public async Task RefreshQuestionList()
        {
            //CHeck its not a new quiz
            if (Quiz == null || QuizId == 0)
                return;

            var questionData = await _quizService.GetQuizAsync(QuizId);

            if (questionData == null)
                return;

            Questions.Clear();
            foreach(var question in questionData.Questions)
            {
                Questions.Add(question);
            }
            
        }

        private async Task SaveQuiz()
        {
            //Check inputs are valid
            if (!await ValidateQuiz())
                return;

            //Save new
            if (Quiz != null && Quiz.Id == 0)
            {
                await _quizService.CreateQuizAsync(Quiz);
            }
            //Update existing
            else
            {
                await _quizService.UpdateQuizAsync(Quiz);
            }

            await Shell.Current.Navigation.PopAsync();
        }

        private async Task DeleteQuiz()
        {
            //Delete quiz
            if (Quiz != null && Quiz.Id > 0)
            {
                await _quizService.DeleteQuizAsync(Quiz.Id);
            }

            await Shell.Current.Navigation.PopAsync();
        }


        private async Task OnQuestionSelected(Question question)
        {
            if (question == null)
                return;

            await Shell.Current.Navigation.PushAsync(new Views.QB.QBEditQuestionPage(Quiz.Id, SelectedQuestion));

            SelectedQuestion = null;
        }

        #endregion

        private async Task<bool> ValidateQuiz()
        {
            string errorMessage = "";
            bool isSucess = true;

            if (string.IsNullOrEmpty(Quiz.Title))
            {
                errorMessage += "Missing Quiz Title" + "\n";
                isSucess = false;
            }

            if (string.IsNullOrEmpty(Quiz.Description))
            {
                errorMessage += "Missing Quiz Description" + "\n";
                isSucess = false;
            }

            if (string.IsNullOrEmpty(Quiz.ImageUrl))
            {
                errorMessage += "Missing Quiz Image URL";
                isSucess = false;
            }

            if(!isSucess)
                Shell.Current.DisplayAlert("Validation Error", errorMessage, "OK");

            return isSucess;
        }
    }
}
