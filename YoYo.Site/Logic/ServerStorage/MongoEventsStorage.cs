using MongoDB.Bson;
using YoYo.Common;

namespace YoYo.Site.Logic.ServerStorage
{
    public class MongoEventsStorage : IEventsStorage
    {
        private readonly MongoStorage _mongoStorage;
        public MongoEventsStorage()
        {
            _mongoStorage = new MongoStorage();
        }

        public void SaveEvent(Event userEvent)
        {
            var document = new BsonDocument
            {
                { "type" , userEvent.Type},
                { "userId", userEvent.UserId },
                { "userId", userEvent.Timespan }
            };

            _mongoStorage.AddDocument(document, "Events");
        }
    }
}