using Provjera.Models.Binding;
using Provjera.Models.ViewModel;
using System.Security.Claims;

namespace Provjera.Services.Interfaces
{
    public interface IAccountService
    {
        Task<TaskViewModel> AddTask(TaskBinding model);
        Task<ToDoListViewModel> AddToDoList(ToDoListBinding model, ClaimsPrincipal user);
        Task<List<TaskViewModel>> GetTasks(int toDoListId);
        Task<ApplicationUserViewModel> GetuserProfile(ClaimsPrincipal user);
        Task<TaskViewModel> RegulateStatus(int taskId);
    }
}