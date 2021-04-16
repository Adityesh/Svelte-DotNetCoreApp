using System;
using Server.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;



namespace Server.Services
{
    public class TodoService
    {
        private readonly IMongoCollection<Todo> _todos;

        public TodoService(ITodoDatabaseSettings settings) 
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _todos = database.GetCollection<Todo>(settings.TodoCollectionName);        
        }

        public List<Todo> Get() => _todos.Find(todo => true).ToList();

        public Todo Get(string id) => _todos.Find<Todo>(todo => todo.ID == id).FirstOrDefault();
    
        public Todo Create(Todo todo) {
            _todos.InsertOne(todo);
            return todo;
        }

        public void Complete(string id) {
            var filter = Builders<Todo>.Filter.Eq(s => s.ID, id);
            var update = Builders<Todo>.Update.Set(s => s.Completed, true);
            _todos.UpdateOne(filter, update);
        }

        public void InComplete(string id) {
            var filter = Builders<Todo>.Filter.Eq(s => s.ID, id);
            var update = Builders<Todo>.Update.Set(s => s.Completed, false);
            _todos.UpdateOne(filter, update);
        }

        public void Remove(string id) {
            _todos.DeleteOne<Todo>(todo => todo.ID == id);
        }

        public List<Todo> CompletedTodos() {
            return _todos.Find<Todo>(todo => todo.Completed == true).ToList();
        }

        
    }
}