using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListAPI.Entities;

namespace ToDoListAPI.Controllers
{
    //200 Ok(get)
    //NoContent(update) 204
    //NoContent(delete) 204
    //Created(add) 201
    
    [Route("api/[controller]/[action]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public ToDoController(AppDbContext context, ILogger<ToDoController> logger)
        {
            _context = context;
            
        }

        [HttpGet]
        public IActionResult GetToDoList()
        {
            var toDoList = _context.Todos.Where(x => x.IsDeleted == false).ToList();
            return Ok(toDoList);
        }



        [HttpGet]
        public IActionResult GetTodoById(int id)
        {
            var todoDetail = _context.Todos.FirstOrDefault(x => x.Id == id);
            return Ok(todoDetail);
        }


        [HttpPut]
        public IActionResult UpDateToDo( Todo todo)
        {
            try
            {
                var toDoToBeUpdated = _context.Todos.Where(x => x.Id == todo.Id && x.IsDeleted == false)
                    .FirstOrDefault();
                toDoToBeUpdated.Id = todo.Id;
                toDoToBeUpdated.TodoText = todo.TodoText;
                toDoToBeUpdated.IsDeleted = false;
                toDoToBeUpdated.UpdatedDate = DateTime.Now;
                var updatedTodo = _context.Todos.Update(toDoToBeUpdated);
                _context.SaveChanges();
                
            }
            catch (Exception)
            {

                throw;
            }

            return NoContent();
        }

        [EnableCors("CorsPolicy")]
        [HttpDelete]
        public IActionResult DeleteTodo(Todo todo)
        {
            var toDoToBeDelete = _context.Todos.FirstOrDefault(x => x.Id == todo.Id);
            var deletedTodo = _context.Todos.Remove(toDoToBeDelete);
            _context.SaveChanges();
            return Ok();

        }
        [EnableCors("CorsPolicy")]
        [HttpPost]
        public IActionResult AddTodo(Todo todo)
        {        
                Todo addedToBeTodo = new Todo();
                addedToBeTodo.TodoText = todo.TodoText;
                addedToBeTodo.IsDeleted = false;
                addedToBeTodo.AddedDate = DateTime.Now;
                var addedTodo = _context.Todos.Add(addedToBeTodo);
                _context.SaveChanges();
            return NoContent();
        }
    }
}
