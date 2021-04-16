using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Server.Model {
    public class Todo {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID {
            get; set;
        }
        
        [BsonElement("Task")]
        public string Task {
            get; set;
        }

        [BsonElement("IsCompleted")]
        public Boolean Completed {
            get; set;
        } = false;

        [BsonElement("Date_Created")]
        public string DateCreated {
            get; set;
        } = DateTime.Now.ToString();
    }
}