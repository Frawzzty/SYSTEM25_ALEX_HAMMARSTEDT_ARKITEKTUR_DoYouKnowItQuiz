using Domain.Entities.Models.EntityFrameworkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Interfaces
{
    public interface IQuizService
    {

        Task<Quiz?> GetQuizAsync(int quizId);
        Task<List<Quiz>> GetAllQuizzesAsync();

        Task CreateQuizAsync(Quiz quiz);
        Task UpdateQuizAsync(Quiz quiz);
        Task DeleteQuizAsync(int quizId);


    }
}
