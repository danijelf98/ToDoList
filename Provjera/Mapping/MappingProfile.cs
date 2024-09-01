using AutoMapper;
using Provjera.Models.Binding;
using Provjera.Models.Dbo;
using Provjera.Models.ViewModel;

namespace Provjera.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserViewModel>();
            CreateMap<ToDoListBinding, ToDoList>();
            CreateMap<ToDoList, ToDoListViewModel>();
            CreateMap<Models.Dbo.Task, TaskViewModel>();
            CreateMap<TaskBinding, Models.Dbo.Task>();
        }
    }
}
