using Domain.Entities.Interfaces;
using Domain.Entities.Models.DbModels;
using DoYouKnowIt.Infrastructure.Connections;
using MongoDB.Driver;

namespace DoYouKnowIt.Infrastructure.Repositories.DbRepositories
{
    public class QuizRepoMongoDb : IQuizRepository
    {
        MongoDbConnection _mongoConnection;
        public QuizRepoMongoDb(MongoDbConnection mongoConnection)
        {
            _mongoConnection = mongoConnection;
        }

        public async Task AddAsync(Quiz quiz)
        {
            await GetMongoQuizCollection().InsertOneAsync(quiz);
        }

        public Task DeleteAsync(int quizId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Quiz>> GetAllAsync()
        {
            return await GetMongoQuizCollection().Find(x => true).ToListAsync();
        }

        public Task<Quiz?> GetByIdAsync(int quizId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Quiz quiz)
        {
            throw new NotImplementedException();
        }


        public IMongoCollection<Quiz> GetMongoQuizCollection()
        {
            var client = _mongoConnection.GetClient();

            var dataBase = client.GetDatabase("DoYouKnowItDb"); // Creats new DB if does not exist
            var collection = dataBase.GetCollection<Quiz>("QuizCollection"); // Creates new Collection in DB if does not exists

            return collection;
        }
    }
}
