using Microsoft.EntityFrameworkCore;
using MyCompany.MyProject.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDddify(builder =>
{
    builder.AddApiResult();

    builder.AddApplication();

    builder.AddLocalization(options =>
    {
        options.SupportedCultures = new[] { "zh-CN", "en-US" };
        options.DefaultCulture = "zh-CN";
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options
    .UseSqlite(builder.Configuration.GetConnectionString("Default"))
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDddify();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
