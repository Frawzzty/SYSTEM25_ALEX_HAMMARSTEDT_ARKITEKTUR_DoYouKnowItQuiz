using Domain.Entities.Interfaces;
using Domain.Entities.Models.DbModels;
using DoYouKnowIt.Application.Extensions;
using DoYouKnowIt.Application.Interfaces.DbServiceInterfaces;

namespace DoYouKnowIt.Application.Services.DbServices
{
    public class QuizService : IQuizService
    {

        private readonly IQuizRepository _quizRepo;

        public QuizService(IQuizRepository quizRepo)
        {
            _quizRepo = quizRepo;
        }

        public async Task<Quiz?> GetQuizAsync(int quizId) 
            => await _quizRepo.GetByIdAsync(quizId);
        public async Task<List<Quiz>> GetAllQuizzesAsync() 
            => await _quizRepo.GetAllAsync();
      

        public async Task CreateQuizAsync(Quiz quiz)
        {
            if (quiz == null)
                return;

            if(quiz.Title != null)
            {
                quiz.Title = quiz.Title.WordsFirstUpper();
            }

            await _quizRepo.AddAsync(quiz);
        }

        public async Task UpdateQuizAsync(Quiz quiz)
        {
            if (quiz == null)
                return;

            if (quiz.Title != null)
            {
                quiz.Title = quiz.Title.WordsFirstUpper();
            }

            await _quizRepo.UpdateAsync(quiz);
        }

        public async Task DeleteQuizAsync(int quizId)
        {
            await _quizRepo.DeleteAsync(quizId);
        }


    }
}
