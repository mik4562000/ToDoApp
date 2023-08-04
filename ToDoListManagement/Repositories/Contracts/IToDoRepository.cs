using toDoListManagement.Models;

namespace toDoListManagement.Repositories.Contracts
{
    public interface IToDoRepository
    {
        public List<ToDoItem> GetToDoItems(int statusId = 0);
        public ToDoItem AddToDoItem(string name);
        public void ChangeToDoItem(int id, string name);
        public StatusInfo CompleteToDoItem(int id);
        public StatusInfo DeleteToDoItem(int id);
        public void RemoveToDoItemForGood(int id);
    }
}
