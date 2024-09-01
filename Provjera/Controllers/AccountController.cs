using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Provjera.Models.Binding;
using Provjera.Models.ViewModel;
using Provjera.Services.Interfaces;

namespace Provjera.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var profile = await accountService.GetuserProfile(User);
            return View(profile);
        }
        [Authorize]
        public async Task<IActionResult> AddToDoList()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToDoList(ToDoListBinding model)
        {
            var profile = await accountService.AddToDoList(model, User);
            return RedirectToAction("Profile");
        }

        [Authorize]
        public async Task<IActionResult> GetAllTasks(int id)
        {
            var tasks = await accountService.GetTasks(id);
            var model = new ListTaskViewModel { List = tasks, ToDoListId = id };
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> RegulateStatus(int id)
        {
            var tasks = await accountService.RegulateStatus(id);
            return RedirectToAction("GetAllTasks", new { id = tasks.ToDoListId });
        }
        [Authorize]
        public async Task<IActionResult> AddTask(int toDoListId)
        {
            return View(new TaskBinding { ToDoListId = toDoListId });
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTask(TaskBinding model)
        {
            var profile = await accountService.AddTask(model);
            return RedirectToAction("GetAllTasks", new { id = model.ToDoListId });
        }
    }
}
