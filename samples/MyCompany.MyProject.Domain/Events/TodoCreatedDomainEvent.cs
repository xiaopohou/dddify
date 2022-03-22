using Dddify.Domain.Events;
using MyCompany.MyProject.Domain.Entities;

namespace MyCompany.MyProject.Domain.DomainEvents;

public class TodoCreatedDomainEvent : IDomainEvent
{
    public Todo Todo { get; private set; }

    public TodoCreatedDomainEvent(Todo todo)
    {
        Todo = todo;
    }
}
