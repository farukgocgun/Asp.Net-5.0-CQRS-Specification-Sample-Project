using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OFG.CqrsSample.Infrastructure.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OFG.CqrsSample.Application.Features.ToDoComment.Commands.CreateToDoComment
{
    public class CreateToDoCommentCommandHandler : IRequestHandler<CreateToDoCommentCommand, int>
    {
        private readonly IGenericRepository<Domain.Entities.ToDoComment> _toDoCommentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateToDoCommentCommandHandler> _logger;

        public CreateToDoCommentCommandHandler(IGenericRepository<Domain.Entities.ToDoComment> toDoCommentRepository, IMapper mapper, ILogger<CreateToDoCommentCommandHandler> logger)
        {
            _toDoCommentRepository = toDoCommentRepository ?? throw new ArgumentNullException(nameof(toDoCommentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreateToDoCommentCommand request, CancellationToken cancellationToken)
        {
            var toDoCommentEntity = _mapper.Map<Domain.Entities.ToDoComment>(request);
            var newToDoComment= await _toDoCommentRepository.AddAsync(toDoCommentEntity);

            await _toDoCommentRepository.SaveChangesAsync();

            _logger.LogInformation($"ToDoComment {newToDoComment.Id} is successfully created.");

            return newToDoComment.Id;
        }
    }
}
