using System;

namespace MyCompany.MyProject.Application.Queries;

public class TodoDto
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string ColourCode { get; set; }
}
