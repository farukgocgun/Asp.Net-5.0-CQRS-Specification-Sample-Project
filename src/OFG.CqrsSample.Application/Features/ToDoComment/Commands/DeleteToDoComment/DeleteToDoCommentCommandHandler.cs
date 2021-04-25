using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OFG.CqrsSample.Application.Exceptions;
using OFG.CqrsSample.Infrastructure.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OFG.CqrsSample.Application.Features.ToDoComment.Commands.DeleteToDoComment
{
    public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommentCommand>
    {
        private readonly IGenericRepository<Domain.Entities.ToDoComment> _toDoCommentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteToDoCommandHandler> _logger;

        public DeleteToDoCommandHandler(IGenericRepository<Domain.Entities.ToDoComment> toDoCommentRepository, IMapper mapper, ILogger<DeleteToDoCommandHandler> logger)
        {
            _toDoCommentRepository = toDoCommentRepository ?? throw new ArgumentNullException(nameof(toDoCommentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteToDoCommentCommand request, CancellationToken cancellationToken)
        {
            var toDoCommentToDelete = await _toDoCommentRepository.GetByIdAsync(request.Id);
            if (toDoCommentToDelete == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.ToDo), request.Id);
            }

            _toDoCommentRepository.Delete(toDoCommentToDelete);

            await _toDoCommentRepository.SaveChangesAsync();

            _logger.LogInformation($"ToDo {toDoCommentToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}