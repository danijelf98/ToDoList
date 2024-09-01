using Provjera.Models.Dbo;

namespace Provjera.Models.ViewModel
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        public string? FulName { get; set; }
        public List<ToDoListViewModel> ToDoLists { get; set; }
    }
}
