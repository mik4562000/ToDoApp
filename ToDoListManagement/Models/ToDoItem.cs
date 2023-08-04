namespace toDoListManagement.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public StatusInfo? Status { get; set; }
    }
}
