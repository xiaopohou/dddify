using Dddify.Domain.Entities;
using MyCompany.MyProject.Domain.Enums;
using System;

namespace MyCompany.MyProject.Domain.Entities
{
    public class TodoItem : FullAuditedEntity<Guid>
    {
        public string Title { get; set; }

        public string Note { get; set; }

        public PriorityLevel Priority { get; set; }

        public DateTime? Reminder { get; set; }
    }
}
