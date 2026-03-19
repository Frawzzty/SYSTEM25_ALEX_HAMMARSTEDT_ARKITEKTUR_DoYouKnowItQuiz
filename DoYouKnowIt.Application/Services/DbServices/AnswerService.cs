using Domain.Entities.Interfaces;
using Domain.Entities.Models.DbModels;
using DoYouKnowIt.Application.Interfaces.DbServiceInterfaces;
using DoYouKnowIt.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Services.DbServices
{
    public class AnswerService : IAnswerService
    {
        IAnswerRepository _answerRepo = new AnswerRepositoryEF();

        public AnswerService(IAnswerRepository answerRepo)
        {
            _answerRepo = answerRepo;
        }

        public async Task<Answer?> GetAnswerAsync(int answerId)
            => await _answerRepo.GetByIdAsync(answerId);

        public async Task<List<Answer>> GetAllAnswerAsync()
            => await _answerRepo.GetAllAsync();



        public async Task CreateAnswernAsync(Answer answer)
        {
            await _answerRepo.AddAsync(answer);
        }

        public async Task UpdateAnswerAsync(Answer answer)
        {
            await _answerRepo.UpdateAsync(answer);
        }

        public async Task DeleteAnswerAsync(int answerId)
        {
            await _answerRepo.DeleteAsync(answerId);
        }
    }
}
