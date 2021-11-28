var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/hello/{name:alpha}", (string name) => $"Hello {name}!");

app.Run();
