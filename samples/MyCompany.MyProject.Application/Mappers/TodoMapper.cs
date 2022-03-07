using Mapster;
using MyCompany.MyProject.Application.Queries;
using MyCompany.MyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.MyProject.Application.Mappers
{
    public class TodoMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<Todo, TodoDto>()
                .Map(dest => dest.Title, src => src.Title + "_AppendSomething!");
        }
    }
}
