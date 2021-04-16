using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Services;
using Server.Model;


namespace Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }
        
        // Get all todos from the database
        [HttpGet]
        public ActionResult<List<Todo>> GetTodo()
        {
            return _todoService.Get();
        }

        // Get todo by the id from the database
        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Todo> GetTodo(string id){
            return _todoService.Get(id);
        }

        // Add a todo to the database
        [Route("/api/[controller]/add")]
        [HttpPost]
        public ActionResult<Todo> AddTodo(string task) 
        {
            return _todoService.Create(new Todo(){
                Task = task
            });
        }

        // Mark a todo as complete
        [Route("/api/[controller]/complete")]
        [HttpPost]
        public IActionResult CompleteTodo(string id) 
        {
            _todoService.Complete(id);
            return Ok(new Response(){
                Message = "Task Marked as complete",
                Error = false
            });
        }

        // Mark a task as incomplete
        [Route("/api/[controller]/incomplete")]
        [HttpPost]
        public IActionResult InCompleteTodo(string id) {
            _todoService.InComplete(id);
            return Ok(new Response(){
                Message = "Task Marked as incomplete",
                Error = false
            });
        }

        // Delete a todo from the database
        [HttpDelete]
        public IActionResult DeleteTodo(string id) 
        {
            _todoService.Remove(id);
            return Ok(new Response(){
                Message = "Task Deleted Successfully",
                Error = false
            });
        }

        // Get all completed todos
        [HttpGet]
        [Route("/api/[controller]/completed")]
        public ActionResult<List<Todo>> GetCompletedTodos() {
            return _todoService.CompletedTodos();
        }
    }
}
