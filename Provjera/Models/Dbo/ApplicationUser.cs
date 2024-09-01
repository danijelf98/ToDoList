using Microsoft.AspNetCore.Identity;

namespace Provjera.Models.Dbo
{
    public class ApplicationUser : IdentityUser
    {
        public string? FulName { get; set; }
        public ICollection<ToDoList> ToDoLists { get; set; }
    }
}
