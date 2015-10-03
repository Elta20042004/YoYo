using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace YoYo.Common
{
    public class MongoStorage
    {
        private readonly IMongoDatabase _database;

        public MongoStorage()
        {
            var client = new MongoClient();
            _database = client.GetDatabase("Shop");
        }

        public void AddDocument(BsonDocument document, string collectionName)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.InsertOneAsync(document);
        }
    }
}