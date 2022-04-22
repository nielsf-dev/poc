var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddAuthentication("");
//builder.Services.AddAuthorization();
//builder.Services.AddHealthChecks();
var app = builder.Build();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapHealthChecks("/healthz").RequireAuthorization();
//app.MapGet("/", () => "Hello World!");

app.Use(async (context, next) =>
{
    Console.WriteLine($"1. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");
    await next(context);
});

app.UseRouting();

app.Use(async (context, next) =>
{
    Console.WriteLine($"2. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");
    await next(context);
});

app.MapGet("/", (HttpContext context) =>
{
    Console.WriteLine($"3. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");
    return "Hello World!";
}).WithDisplayName("Hello");

app.UseEndpoints(_ => { });

app.Use(async (context, next) =>
{
    Console.WriteLine($"4. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");
    await next(context);
});

app.Run();
