using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OFG.CqrsSample.Application.Helpers;
using OFG.CqrsSample.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OFG.CqrsSample.Application.Features.ToDoComment.Queries
{
    public class GetToDoCommentListQueryHandler : IRequestHandler<GetToDoCommentListQuery, Pagination<ToDoCommentResponse>>
    {
        private readonly IGenericRepository<Domain.Entities.ToDoComment> _toDoCommentRepository;
        private readonly ILogger<GetToDoCommentListQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetToDoCommentListQueryHandler(IGenericRepository<Domain.Entities.ToDoComment> toDoCommentRepository, ILogger<GetToDoCommentListQueryHandler> logger, IMapper mapper)
        {
            _toDoCommentRepository = toDoCommentRepository ?? throw new ArgumentNullException(nameof(toDoCommentRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Pagination<ToDoCommentResponse>> Handle(GetToDoCommentListQuery request, CancellationToken cancellationToken)
        {
            var spec = new ToDoCommentSpec(request);
            var countSpec = new ToDoCommentWithFiltersForCountSpec(request);
            var totalItems = await _toDoCommentRepository.CountAsync(countSpec);
            var todo = await _toDoCommentRepository.ListWithSpecAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Domain.Entities.ToDoComment>, IReadOnlyList<ToDoCommentResponse>>(todo);

            return new Pagination<ToDoCommentResponse>(request.PageIndex, request.PageSize, totalItems, data);
        }
    }
}
