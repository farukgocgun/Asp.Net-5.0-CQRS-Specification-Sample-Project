using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OFG.CqrsSample.Application.Exceptions;
using OFG.CqrsSample.Infrastructure.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OFG.CqrsSample.Application.Features.ToDo.Commands.DeleteToDo
{
    public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommand>
    {
        private readonly IGenericRepository<Domain.Entities.ToDo> _ToDoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteToDoCommandHandler> _logger;

        public DeleteToDoCommandHandler(IGenericRepository<Domain.Entities.ToDo> ToDoRepository, IMapper mapper, ILogger<DeleteToDoCommandHandler> logger)
        {
            _ToDoRepository = ToDoRepository ?? throw new ArgumentNullException(nameof(ToDoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            var ToDoToDelete = await _ToDoRepository.GetByIdAsync(request.Id);
            if (ToDoToDelete == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.ToDo), request.Id);
            }

            _ToDoRepository.Delete(ToDoToDelete);

            await _ToDoRepository.SaveChangesAsync();

            _logger.LogInformation($"ToDo {ToDoToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}