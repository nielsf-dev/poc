using Microsoft.Extensions.Hosting;

namespace HostBuilding;

public class MyHostedService : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Start hosted service");
        Thread t = new Thread(mymethod);
        t.Start();

        return Task.CompletedTask;
    }

    private void mymethod(object? obj)
    {
        while (true)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine("Sleeping");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Stop hosted service");
        return Task.CompletedTask;
    }
}