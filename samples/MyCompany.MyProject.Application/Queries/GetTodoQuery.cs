using MediatR;
using MyCompany.MyProject.Infrastructure;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dddify.EntityFrameworkCore;
using MapsterMapper;
using Mapster;
using Dddify.Exceptions;
using MyCompany.MyProject.Domain.Entities;

namespace MyCompany.MyProject.Application.Queries
{
    public class GetTodoQuery : IRequest<TodoDto>
    {
        public Guid Id { get; set; }
    }

    public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, TodoDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTodoQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TodoDto> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            var todo = await _context.Todos
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (todo == null)
            {
                throw new NotFoundException(nameof(Todo), request.Id);
            }

            return todo.Adapt<TodoDto>();
        }
    }
}
