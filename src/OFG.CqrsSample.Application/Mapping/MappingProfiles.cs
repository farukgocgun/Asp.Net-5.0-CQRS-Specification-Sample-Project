using AutoMapper;
using OFG.CqrsSample.Application.Features.ToDo.Commands.CreateToDo;
using OFG.CqrsSample.Application.Features.ToDo.Commands.UpdateToDo;
using OFG.CqrsSample.Application.Features.ToDo.Queries;
using OFG.CqrsSample.Domain.Entities;

namespace OFG.CqrsSample.Application.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ToDo, ToDoResponse>().ReverseMap();
            CreateMap<ToDo, CreateToDoCommand>().ReverseMap();
            CreateMap<ToDo, UpdateToDoCommand>().ReverseMap();

            CreateMap<TodoComment, ToDoCommentResponse>().ReverseMap();
            CreateMap<TodoComment, CreateToDoCommentCommand>().ReverseMap();
            CreateMap<TodoComment, UpdateToDoCommentCommand>().ReverseMap();
        }
    }

}
