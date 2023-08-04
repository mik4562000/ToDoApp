using Microsoft.AspNetCore.Mvc;
using toDoListManagement.Models;
using toDoListManagement.Services;
using toDoListManagement.Services.Contracts;

namespace toDoListManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        public ToDoController(IToDoService toDoService) {
            _toDoService = toDoService;
        }

        [HttpGet("GetAllToDoItems")]
        public IEnumerable<ToDoItem> GetAllToDoItems()
        {
            return _toDoService.GetAllToDoItems();
        }

        [HttpGet("GetCompletedToDoItems")]
        public IEnumerable<ToDoItem> GetCompletedToDoItems()
        {
            return _toDoService.GetCompletedToDoItems();
        }

        [HttpGet("GetDeletedToDoItems")]
        public IEnumerable<ToDoItem> GetDeletedToDoItems()
        {
            return _toDoService.GetDeletedToDoItems();
        }

        [HttpPost("AddToDoItem")]
        public ToDoItem AddToDoItem(string name)
        {
            return _toDoService.AddToDoItem(name);
        }

        [HttpPut("ChangeToDoItem")]
        public void ChangeToDoItem(int id, string name)
        {
            _toDoService.ChangeToDoItem(id, name);
        }

        [HttpDelete("RemoveToDoItem")]
        public void RemoveToDoItem(int id)
        {
            _toDoService.RemoveToDoItemForGood(id);
        }

        [HttpPut("CompleteToDoItem")]
        public StatusInfo CompleteToDoItem(int id)
        {
            return _toDoService.CompleteToDoItem(id);
        }

        [HttpPut("DeleteToDoItem")]
        public StatusInfo DeleteToDoItem(int id)
        {
            return _toDoService.DeleteToDoItem(id);
        }
    }

    
}
