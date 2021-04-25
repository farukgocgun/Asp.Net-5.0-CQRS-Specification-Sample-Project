using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OFG.CqrsSample.Application.Exceptions;
using OFG.CqrsSample.Infrastructure.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OFG.CqrsSample.Application.Features.ToDoComment.Commands.UpdateToDoComment
{
    public class UpdateToDoCommentCommandHandler : IRequestHandler<UpdateToDoCommentCommand>
    {
        private readonly IGenericRepository<Domain.Entities.ToDoComment> _toDoCommentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateToDoCommentCommandHandler> _logger;

        public UpdateToDoCommentCommandHandler(IGenericRepository<Domain.Entities.ToDoComment> toDoCommentRepository, IMapper mapper, ILogger<UpdateToDoCommentCommandHandler> logger)
        {
            _toDoCommentRepository = toDoCommentRepository ?? throw new ArgumentNullException(nameof(toDoCommentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateToDoCommentCommand request, CancellationToken cancellationToken)
        {
            var toDoCommentToUpdate = await _toDoCommentRepository.GetByIdAsync(request.Id);
            if (toDoCommentToUpdate == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.ToDoComment), request.Id);
            }

            _mapper.Map(request, toDoCommentToUpdate, typeof(UpdateToDoCommentCommand), typeof(Domain.Entities.ToDoComment));

            _toDoCommentRepository.Update(toDoCommentToUpdate);

            _logger.LogInformation($"toDo {toDoCommentToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
