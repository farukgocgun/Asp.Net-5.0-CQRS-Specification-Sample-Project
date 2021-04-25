using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OFG.CqrsSample.Application.Exceptions;
using OFG.CqrsSample.Infrastructure.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OFG.CqrsSample.Application.Features.ToDo.Commands.UpdateToDo
{
    public class UpdateToDoCommandHandler : IRequestHandler<UpdateToDoCommand>
    {
        private readonly IGenericRepository<Domain.Entities.ToDo> _toDoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateToDoCommandHandler> _logger;

        public UpdateToDoCommandHandler(IGenericRepository<Domain.Entities.ToDo> toDoRepository, IMapper mapper, ILogger<UpdateToDoCommandHandler> logger)
        {
            _toDoRepository = toDoRepository ?? throw new ArgumentNullException(nameof(toDoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            var toDoToUpdate = await _toDoRepository.GetByIdAsync(request.Id);
            if (toDoToUpdate == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.ToDo), request.Id);
            }

            _mapper.Map(request, toDoToUpdate, typeof(UpdateToDoCommand), typeof(Domain.Entities.ToDo));

            _toDoRepository.Update(toDoToUpdate);

            _logger.LogInformation($"toDo {toDoToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
