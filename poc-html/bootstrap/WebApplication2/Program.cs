var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();

app.MapRazorPages();

someConfigurationFunction("ditdus");
var hostLifetime = app.Services.GetService<IHostLifetime>();

app.Run();

void someConfigurationFunction(string whatevert)
{
    Console.WriteLine($"Hoort er ook bij -> {whatevert}");
}