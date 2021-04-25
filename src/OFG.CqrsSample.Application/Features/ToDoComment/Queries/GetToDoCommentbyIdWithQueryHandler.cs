using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OFG.CqrsSample.Application.Exceptions;
using OFG.CqrsSample.Infrastructure.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OFG.CqrsSample.Application.Features.ToDoComment.Queries
{
    public class GetToDoCommentbyIdWithQueryHandler : IRequestHandler<GetToDoCommentbyIdWithQuery, ToDoCommentResponse>
    {
        private readonly IGenericRepository<Domain.Entities.ToDoComment> _toDoRepository;
        private readonly ILogger<GetToDoCommentbyIdWithQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetToDoCommentbyIdWithQueryHandler(IGenericRepository<Domain.Entities.ToDoComment> ToDoRepository, ILogger<GetToDoCommentbyIdWithQueryHandler> logger, IMapper mapper)
        {
            _toDoRepository = ToDoRepository ?? throw new ArgumentNullException(nameof(ToDoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ToDoCommentResponse> Handle(GetToDoCommentbyIdWithQuery request, CancellationToken cancellationToken)
        {
            var spec = new ToDoCommentSpec(request.Id);
            var data = await _toDoRepository.GetEntityWithSpec(spec);
            if (data == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.ToDoComment), request.Id);
            }
            _logger.LogInformation($"Succesfully Gets ToDo: {request.Id}");

            return _mapper.Map<ToDoCommentResponse>(data);
        }
    }
}
