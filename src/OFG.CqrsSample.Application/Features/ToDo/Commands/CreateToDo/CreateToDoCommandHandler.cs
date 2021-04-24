using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OFG.CqrsSample.Infrastructure.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OFG.CqrsSample.Application.Features.ToDo.Commands.CreateToDo
{
    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand, int>
    {
        private readonly IGenericRepository<Domain.Entities.ToDo> _toDoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateToDoCommandHandler> _logger;

        public CreateToDoCommandHandler(IGenericRepository<Domain.Entities.ToDo> toDoRepository, IMapper mapper, ILogger<CreateToDoCommandHandler> logger)
        {
            _toDoRepository = toDoRepository ?? throw new ArgumentNullException(nameof(toDoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var toDoEntity = _mapper.Map<Domain.Entities.ToDo>(request);
            var newToDo= await _toDoRepository.AddAsync(toDoEntity);

            await _toDoRepository.SaveChangesAsync();

            _logger.LogInformation($"ToDo {newToDo.Id} is successfully created.");

            return newToDo.Id;
        }
    }
}
