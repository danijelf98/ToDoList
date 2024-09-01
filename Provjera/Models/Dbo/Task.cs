using System.ComponentModel.DataAnnotations;

namespace Provjera.Models.Dbo
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public ToDoList? ToDoList { get; set; }
        public int? ToDoListId { get; set; }
    }
}
