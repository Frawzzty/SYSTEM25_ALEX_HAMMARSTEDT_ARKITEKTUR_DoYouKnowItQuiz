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

        public bool IsInitialized = false;
        public QBEditQuizPageViewModel(IQuizService quizService)
        {
            _quizService = quizService;

            //Commands
            AddNewQuestionCommand = new Command(async () => {
                await Shell.Current.GoToAsync($"{nameof(Views.QB.QBEditQuestionPage)}?QuizId={QuizId}&QuestionId={0}");});

            SaveQuizCommand = new Command(async () => { await SaveQuiz(); });
            DeleteQuizCommand = new Command(async () => { await DeleteQuiz(); });
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

        //Bound to CollectionView.ItemSelected
        private Question _selectedQuestion;
        public Question SelectedQuestion
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

        private ObservableCollection<Question> _questions = new();
        public ObservableCollection<Question> Questions { get { return _questions; } set { _questions = value; OnPropertyChanged(nameof(Questions)); } }


        //Refreshes on appearing
        public async Task LoadData()
        {

            Quiz = await _quizService.GetQuizAsync(QuizId) ?? new();

            if (Quiz == null)
                return;

            Questions = new ObservableCollection<Question>(Quiz.Questions);
            IsInitialized = true;
        }


        #region Methods

        private async Task SaveQuiz()
        {
            if (ValidateQuiz() == false)
                return;

            //Save new
            if (Quiz != null && Quiz.Id == 0)
                await _quizService.CreateQuizAsync(Quiz);

            //Update existing
            else
                await _quizService.UpdateQuizAsync(Quiz);
            
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

            await Shell.Current.GoToAsync($"{nameof(Views.QB.QBEditQuestionPage)}?QuizId={question.QuizId}&QuestionId={question.Id}");

            SelectedQuestion = null;
        }

        #endregion

        private bool ValidateQuiz()
        {
            string errorMessages = "";
            bool isSucess = true;

            if (string.IsNullOrEmpty(Quiz.Title))
            {
                errorMessages += "Missing Quiz Title" + "\n";
                isSucess = false;
            }

            if (string.IsNullOrEmpty(Quiz.Description))
            {
                errorMessages += "Missing Quiz Description" + "\n";
                isSucess = false;
            }

            if (string.IsNullOrEmpty(Quiz.ImageUrl))
            {
                errorMessages += "Missing Quiz Image URL";
                isSucess = false;
            }

            if(!isSucess)
                Shell.Current.DisplayAlert("Validation Error", errorMessages, "OK");

            return isSucess;
        }
    }
}
