using MediatR;
using MyCompany.MyProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dddify.EntityFrameworkCore;
using Mapster;

namespace MyCompany.MyProject.Application.Queries
{
    public class GetTodoPagedListQuery : IRequest<IPagedList<TodoDto>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }

    public class GetTodoPagedListQueryHandler : IRequestHandler<GetTodoPagedListQuery, IPagedList<TodoDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetTodoPagedListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IPagedList<TodoDto>> Handle(GetTodoPagedListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Todos
                .AsNoTracking()
                .ProjectToType<TodoDto>()
                .OrderBy(c => c.Title)
                .ToPagedListAsync(request.Page, request.Size, cancellationToken);
        }
    }
}
