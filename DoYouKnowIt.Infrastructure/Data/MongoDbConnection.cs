using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Infrastructure.Data
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
