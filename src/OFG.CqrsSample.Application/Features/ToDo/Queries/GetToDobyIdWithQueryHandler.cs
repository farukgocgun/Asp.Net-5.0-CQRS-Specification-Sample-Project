using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OFG.CqrsSample.Application.Exceptions;
using OFG.CqrsSample.Infrastructure.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OFG.CqrsSample.Application.Features.ToDo.Queries
{
    public class GetToDobyIdWithQueryHandler : IRequestHandler<GetToDobyIdWithQuery, ToDoResponse>
    {
        private readonly IGenericRepository<Domain.Entities.ToDo> _toDoRepository;
        private readonly ILogger<GetToDobyIdWithQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetToDobyIdWithQueryHandler(IGenericRepository<Domain.Entities.ToDo> ToDoRepository, ILogger<GetToDobyIdWithQueryHandler> logger, IMapper mapper)
        {
            _toDoRepository = ToDoRepository ?? throw new ArgumentNullException(nameof(ToDoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ToDoResponse> Handle(GetToDobyIdWithQuery request, CancellationToken cancellationToken)
        {
            var spec = new ToDoSpec(request.Id);
            var data = await _toDoRepository.GetEntityWithSpec(spec);
            if (data == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.ToDo), request.Id);
            }
            _logger.LogInformation($"Succesfully Gets ToDo: {request.Id}");

            return _mapper.Map<ToDoResponse>(data);
        }
    }
}
