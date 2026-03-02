using Domain.Entities.Models.EntityFrameworkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Interfaces
{
    public interface IAnswerService
    {
        Task<Answer?> GetAnswerAsync(int answerId);
        Task<List<Answer>> GetAllAnswerAsync();

        Task CreateAnswernAsync(Answer answer);
        Task UpdateAnswerAsync(Answer answer);
        Task DeleteAnswerAsync(int answerId);
    }
}
