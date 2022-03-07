using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MyCompany.MyProject.Domain.Entities;
using MyCompany.MyProject.Domain.ValueObjects;
using MyCompany.MyProject.Infrastructure;
using Dddify.Guids;
using Mapster;
using MyCompany.MyProject.Application.Queries;
using MyCompany.MyProject.Domain.Enums;
using Dddify.Timing;

namespace MyCompany.MyProject.Application.Commands
{
    public class CreateTodoCommand : IRequest<TodoDto>
    {
        public string Title { get; set; }

        public Colour Colour { get; set; }
    }

    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, TodoDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IClock _clock;

        public CreateTodoCommandHandler(ApplicationDbContext context, IClock clock)
        {
            _context = context;
            _clock = clock;
        }

        public async Task<TodoDto> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = new Todo(request.Title, request.Colour);

            todo.AddItem(new TodoItem
            {
                Title = "Title",
                Note = "Note",
                Priority = PriorityLevel.High,
                Reminder = _clock.Now,
            });

            await _context.Todos.AddAsync(todo, cancellationToken);
            await _context.SaveEntitiesAsync(cancellationToken);

            return todo.Adapt<TodoDto>();
        }
    }
}
