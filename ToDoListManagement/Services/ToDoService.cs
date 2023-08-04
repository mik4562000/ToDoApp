using toDoListManagement.Models;
using toDoListManagement.Models.Enums;
using toDoListManagement.Repositories.Contracts;
using toDoListManagement.Services.Contracts;

namespace toDoListManagement.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        public ToDoService(IToDoRepository toDoRepository) {
            _toDoRepository= toDoRepository;
        }
        public List<ToDoItem> GetAllToDoItems()
        {
            return _toDoRepository.GetToDoItems();
        }
        public ToDoItem AddToDoItem(string name)
        {
            return _toDoRepository.AddToDoItem(name);
        }
        public void ChangeToDoItem(int id, string name)
        {
            _toDoRepository.ChangeToDoItem(id, name);
        }

        public List<ToDoItem> GetCompletedToDoItems()
        {
            return _toDoRepository.GetToDoItems(StatusEnum.Completed);
        }

        public List<ToDoItem> GetDeletedToDoItems()
        {
            return _toDoRepository.GetToDoItems(StatusEnum.Deleted);
        }

        public StatusInfo CompleteToDoItem(int id)
        {
            return _toDoRepository.CompleteToDoItem(id);
        }

        public StatusInfo DeleteToDoItem(int id)
        {
            return _toDoRepository.DeleteToDoItem(id);
        }

        public void RemoveToDoItemForGood(int id)
        {
            _toDoRepository.RemoveToDoItemForGood(id);
        }
    }
}
