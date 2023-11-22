using Microsoft.EntityFrameworkCore;
using TestWebApi;
using TestWebApi.Services;
using TestWebApi.Services.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

builder.Services.AddDbContext<NotesContext>(op =>
{
    op.UseSqlite("Data Source=database.db");
});

builder.Services.AddScoped<NoteRepository>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.ApplyDevelopmentMiddleware();
}

app.MapGet("/hello_world", () => "Hello World!");

app.MapGet("/greet/{name}", async (HttpResponse response, string name) =>
{
    await response.WriteAsync($"<h1>Hello {name}!</h1>");
});

app.MapGet("/error", () => "Error!");

app.MapControllers();

app.Run();