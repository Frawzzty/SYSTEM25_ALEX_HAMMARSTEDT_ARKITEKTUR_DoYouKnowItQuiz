using Domain.Entities.Models.DbModels;
using DoYouKnowIt.Application.Facades;
using DoYouKnowIt.Application.Interfaces.DbServiceInterfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DoYouKnowIt.Presentation.ViewModels.QB
{
    public class QBSelectPageViewModel : INotifyPropertyChanged
    {
        IQuizService _quizService;
        ILoginFacade _loginFacade;
        public QBSelectPageViewModel(IQuizService quizService, ILoginFacade loginFacade)
        {
            _quizService = quizService;
            _loginFacade = loginFacade;
            
            AddNewQuizCommand = new Command(async () => AddNewQuiz()); //Send no Quiz ID parameter
        }

        public ICommand AddNewQuizCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private ObservableCollection<Quiz> _quizzes = new ObservableCollection<Quiz>();
        public ObservableCollection<Quiz> Quizzes { get { return _quizzes; } set { _quizzes = value; OnPropertyChanged(nameof(Quizzes)); } }


        //Bound to CollectionVeiw.SelectedItem
        private Quiz _selectedQuiz;
        public Quiz SelectedQuiz 
        {
            get { return _selectedQuiz; }
            set
            {
                //If same selection? Remove?
                if (_selectedQuiz == value)
                    return;

                _selectedQuiz = value;
                OnPropertyChanged(nameof(SelectedQuiz));

                OnQuizSelected(value);
            }
        }


        private async Task OnQuizSelected(Quiz quiz)
        {
            if (quiz == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(Views.QB.QBEditQuizPage)}?QuizId={quiz.Id}");

            SelectedQuiz = null;
        }

        private async Task AddNewQuiz()
        {
            //Admin lock
            if (await _loginFacade.UserIsAdminAsync() == false)
            {
                await Shell.Current.DisplayAlert("You are not an Admin", "Please login as admin to use the QuizBuilder", "OK");
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(Views.QB.QBEditQuizPage)}");
        }

        public async Task LoadData()
        {
            //Admin lock
            if (await _loginFacade.UserIsAdminAsync() == false)
                return;

            try
            {
                Quizzes = new ObservableCollection<Quiz>(await _quizService.GetAllQuizzesAsync());
            }
            catch (Exception ex)
            {
                Shell.Current.DisplayAlert("Error", $"Problem loading Quizzes, try refresh the page\nError message: {ex.Message}", "OK");
            }
            
        }
    }
}
