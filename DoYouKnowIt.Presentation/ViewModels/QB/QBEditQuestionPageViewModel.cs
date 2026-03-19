using Domain.Entities.Models.DbModels;
using DoYouKnowIt.Application.Interfaces.DbServiceInterfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DoYouKnowIt.Presentation.ViewModels.QB
{
    [QueryProperty(nameof(QuizId), "QuizId")]
    [QueryProperty(nameof(QuestionId), "QuestionId")]
    public class QBEditQuestionPageViewModel : INotifyPropertyChanged
    {
        IQuestionService _questionService;
        IAnswerService _answerService;

        public bool IsInitialized = false;
        public QBEditQuestionPageViewModel(IQuestionService questionService, IAnswerService answerService)
        {
            _questionService = questionService;
            _answerService = answerService;

            //Commands
            SaveQuestionCommand = new Command(async () => await SaveQuestion());
            DeleteQuestionCommand = new Command(async () => await DeleteQuestion());
            AddNewAnswerCommand = new Command(async () => { await Shell.Current.GoToAsync($"{nameof(Views.QB.QBEditAnswerPage)}?QuestionId={Question.Id}&AnswerId={0}"); });
        }

        public async Task LoadData()
        {
            //Get Question, if new create new Question() with correct QuizId
            try 
            { 
                Question = await _questionService.GetQuestionAsync(QuestionId) ?? new() { QuizId = QuizId }; 
            }
            catch (Exception ex) { Shell.Current.DisplayAlert("Error", $"Problem loading data, refreshing the page might fix it\nError message: {ex.Message}", "OK"); }

            if (Question == null)
                return;

            Answers = new ObservableCollection<Answer>(Question.Answers);
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

        //Query Props
        private int _quizId;
        private int _questionId;
        public int QuizId { get { return _quizId; } set { _quizId = value; OnPropertyChanged(nameof(QuizId)); } }
        public int QuestionId { get { return _questionId; } set { _questionId = value; OnPropertyChanged(nameof(QuestionId)); } }


        //Question
        private Question? _question;
        public Question? Question { get { return _question; } set { _question = value; OnPropertyChanged(nameof(Question)); } }


        //Question List
        private ObservableCollection<Answer> _answers = new();
        public ObservableCollection<Answer> Answers { get { return _answers; } set { _answers = value; OnPropertyChanged(nameof(Answers)); } }


        //Bound to CollectionVeiw.SelectedItem
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

            await Shell.Current.GoToAsync($"{nameof(Views.QB.QBEditAnswerPage)}?QuestionId={Question.Id}&AnswerId={SelectedAnswer.Id}"); 

            SelectedAnswer = null;
        }


        private async Task SaveQuestion()
        {
            //Check inputs are valid
            if (ValidateQuestion() == false)
                return;

            //Save new
            if (_question != null && _question.Id == 0)
            {
                try
                {
                    await _questionService.CreateQuestionAsync(_question);
                }
                catch (Exception ex)  { Shell.Current.DisplayAlert("Error", $"Could not create question. Error message: {ex.Message}", "OK"); }
            }
            //Update existing
            else
            {
                try
                {
                    await _questionService.UpdateQuestionAsync(_question);
                }
                catch (Exception ex) { Shell.Current.DisplayAlert("Error", $"Could not update question. Error message: {ex.Message}", "OK"); }
            }

            await Shell.Current.Navigation.PopAsync();
        }

        private async Task DeleteQuestion()
        {
            //Delete quiz
            if (_question != null && _question.Id > 0)
            {
                try
                {
                    await _questionService.DeleteQuestionAsync(_question.Id);
                }
                catch(Exception ex) { Shell.Current.DisplayAlert("Error", $"Something went wrong when deleteting question. Error message: {ex.Message}", "OK");}
            }

            await Shell.Current.Navigation.PopAsync();
        }

        private bool ValidateQuestion()
        {
            string errorMessage = "";
            bool isSucess = true;

            if (string.IsNullOrEmpty(Question.QuestionText))
            {
                errorMessage += "Missing Question text" + "\n";
                isSucess = false;
            }

            if (string.IsNullOrEmpty(Question.QuestionImageUrl))
            {
                errorMessage += "Missing Question Image URL";
                isSucess = false;
            }

            if (!isSucess)
                Shell.Current.DisplayAlert("Validation Error", errorMessage, "OK");

            return isSucess;
        }
    }
}
