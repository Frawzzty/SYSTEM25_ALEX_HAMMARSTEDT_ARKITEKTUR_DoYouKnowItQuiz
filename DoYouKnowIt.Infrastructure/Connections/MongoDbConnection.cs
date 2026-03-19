using MongoDB.Driver;

namespace DoYouKnowIt.Infrastructure.Connections
{
    public class MongoDbConnection
    {
        public MongoClient GetClient()
        {
            var connStr = "mongodb+srv://alexh_db_user:JHp0b6l1LcwnCQzF@cluster0.qwoupuh.mongodb.net/?appName=Cluster0"; // :D //Super secret
            
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connStr));
            MongoClient client = new MongoClient(settings);

            return client;
        }
    }
}
