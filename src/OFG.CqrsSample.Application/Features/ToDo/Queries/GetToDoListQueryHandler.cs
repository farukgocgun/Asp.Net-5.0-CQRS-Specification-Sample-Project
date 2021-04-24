using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OFG.CqrsSample.Application.Helpers;
using OFG.CqrsSample.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OFG.CqrsSample.Application.Features.ToDo.Queries
{
    public class GetToDoListQueryHandler : IRequestHandler<GetToDoListQuery, Pagination<ToDoResponse>>
    {
        private readonly IGenericRepository<Domain.Entities.ToDo> _toDoRepository;
        private readonly ILogger<GetToDoListQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetToDoListQueryHandler(IGenericRepository<Domain.Entities.ToDo> ToDoRepository, ILogger<GetToDoListQueryHandler> logger, IMapper mapper)
        {
            _toDoRepository = ToDoRepository ?? throw new ArgumentNullException(nameof(ToDoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Pagination<ToDoResponse>> Handle(GetToDoListQuery request, CancellationToken cancellationToken)
        {
            var spec = new ToDoSpec(request);
            var countSpec = new ToDoWithFiltersForCountSpec(request);
            var totalItems = await _toDoRepository.CountAsync(countSpec);
            var todo = await _toDoRepository.ListWithSpecAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Domain.Entities.ToDo>, IReadOnlyList<ToDoResponse>>(todo);

            return new Pagination<ToDoResponse>(request.PageIndex, request.PageSize, totalItems, data);
        }
    }
}
