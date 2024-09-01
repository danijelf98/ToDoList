namespace Provjera.Models.ViewModel
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int? ToDoListId { get; set; }
    }
    public class ListTaskViewModel
    {
        public List<TaskViewModel> List { get; set; }
        public int? ToDoListId { get; set; }
    }
}
