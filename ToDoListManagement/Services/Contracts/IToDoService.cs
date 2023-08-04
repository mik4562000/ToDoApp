using toDoListManagement.Models;

namespace toDoListManagement.Services.Contracts
{
    public interface IToDoService
    {
        public List<ToDoItem> GetAllToDoItems();
        public List<ToDoItem> GetCompletedToDoItems();
        public List<ToDoItem> GetDeletedToDoItems();
        public ToDoItem AddToDoItem(string name);
        public void ChangeToDoItem(int id, string name);
        public StatusInfo CompleteToDoItem(int id);
        public StatusInfo DeleteToDoItem(int id);
        public void RemoveToDoItemForGood(int id);
    }
}
