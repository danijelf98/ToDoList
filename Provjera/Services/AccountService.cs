using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Provjera.Data;
using Provjera.Models.Binding;
using Provjera.Models.Dbo;
using Provjera.Models.ViewModel;
using Provjera.Services.Interfaces;
using System.Security.Claims;

namespace Provjera.Services
{
    public class AccountService : IAccountService
    {
        private UserManager<ApplicationUser> userManager;
        private ApplicationDbContext db;
        private readonly IMapper mapper;
        private SignInManager<ApplicationUser> signInManager;

        public AccountService(UserManager<ApplicationUser> userManager, ApplicationDbContext db, IMapper mapper, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.db = db;
            this.mapper = mapper;
            this.signInManager = signInManager;
        }

        public async Task<ApplicationUserViewModel> GetuserProfile(ClaimsPrincipal user)
        {
            var dbo = await db.Users
                .Include(x => x.ToDoLists)
                .ThenInclude(x => x.Tasks)
                .FirstOrDefaultAsync(x => x.Id == userManager.GetUserId(user));

            return mapper.Map<ApplicationUserViewModel>(dbo);
        }
        public async Task<ToDoListViewModel> AddToDoList(ToDoListBinding model, ClaimsPrincipal user)
        {
            var dbo = mapper.Map<ToDoList>(model);
            dbo.ApplicationUserId = userManager.GetUserId(user);
            await db.ToDoLists.AddAsync(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<ToDoListViewModel>(dbo);
        }
        /// <summary>
        /// Add Task to ToDoList
        /// </summary>
        /// <param name="model"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<TaskViewModel> AddTask(TaskBinding model)
        {
            var dbo = mapper.Map<Models.Dbo.Task>(model);
            dbo.Status = true;
            await db.Tasks.AddAsync(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<TaskViewModel>(dbo);
        }
        /// <summary>
        /// Regulate Status Task
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task<TaskViewModel> RegulateStatus(int taskId)
        {
            var dbo = await db.Tasks.FirstOrDefaultAsync(y => y.Id == taskId);
            dbo.Status = false;
            await db.SaveChangesAsync();
            return mapper.Map<TaskViewModel>(dbo);
        }
        public async Task<List<TaskViewModel>> GetTasks(int toDoListId)
        {
            var tasks = await db.Tasks
                .Include(y => y.ToDoList)
                .Where(y => y.ToDoListId == toDoListId && y.Status).ToListAsync();

            return tasks.Select(y => mapper.Map<TaskViewModel>(y)).ToList();
        }

    }
}
