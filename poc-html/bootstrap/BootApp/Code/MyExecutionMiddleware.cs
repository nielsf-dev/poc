using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BootApp.Code;

public class MyExecutionMiddleware
{
    private readonly RequestDelegate next;

    public MyExecutionMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context, BootAppDbContext dbContext)
    {
        await dbContext.Persons.ToListAsync();
        await Task.Delay(2);
        await next(context);
    }
}