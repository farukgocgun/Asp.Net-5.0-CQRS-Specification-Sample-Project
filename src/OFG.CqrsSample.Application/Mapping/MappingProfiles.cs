using AutoMapper;
using OFG.CqrsSample.Application.Features.ToDo.Commands.CreateToDo;
using OFG.CqrsSample.Application.Features.ToDo.Commands.UpdateToDo;
using OFG.CqrsSample.Application.Features.ToDo.Queries;
using OFG.CqrsSample.Application.Features.ToDoComment.Commands.CreateToDoComment;
using OFG.CqrsSample.Application.Features.ToDoComment.Commands.UpdateToDoComment;
using OFG.CqrsSample.Application.Features.ToDoComment.Queries;
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

            CreateMap<ToDoComment, ToDoCommentResponse>().ReverseMap();
            CreateMap<ToDoComment, CreateToDoCommentCommand>().ReverseMap();
            CreateMap<ToDoComment, UpdateToDoCommentCommand>().ReverseMap();
        }
    }

}
