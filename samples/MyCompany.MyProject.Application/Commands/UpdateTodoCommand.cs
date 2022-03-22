using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MyCompany.MyProject.Domain.ValueObjects;
using MyCompany.MyProject.Infrastructure;
using Dddify.Exceptions;
using MyCompany.MyProject.Domain.Entities;
using Mapster;
using MyCompany.MyProject.Application.Queries;

namespace MyCompany.MyProject.Application.Commands;

public class UpdateTodoCommand : IRequest<TodoDto>
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public Colour Colour { get; set; }
}

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, TodoDto>
{
    private readonly ApplicationDbContext _context;

    public UpdateTodoCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TodoDto> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _context.Todos.FindAsync(new object[] { request.Id }, cancellationToken);

        if (todo == null)
        {
            throw new NotFoundException(nameof(Todo), request.Id);
        }

        todo.Title = request.Title;
        todo.Colour = request.Colour;

        await _context.SaveEntitiesAsync(cancellationToken);

        return todo.Adapt<TodoDto>();
    }
}
