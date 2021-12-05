using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BootApp.Code;

internal class MyService : IHostedService
{
    private readonly ILogger logger;
    private readonly IHostApplicationLifetime appLifetime;
    private Timer timer;
    private Task _loopTask;

    public MyService(ILogger<MyService> logger, IHostApplicationLifetime appLifetime)
    {
        this.logger = logger;
        this.appLifetime = appLifetime;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        appLifetime.ApplicationStarted.Register(OnStarted);
        appLifetime.ApplicationStopping.Register(OnStopping);
        appLifetime.ApplicationStopped.Register(OnStopped);

        //_loopTask = loopAwait(cancellationToken);

        _loopTask = loopAwait(cancellationToken);

       // return Task.CompletedTask;
        // timer = new Timer(loopInBackground, cancellationToken, 0, 5000);
        return Task.CompletedTask;
    }

    private async Task loopAwait(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            //logger.LogInformation("Sleeping in await");
            await expensiveTask(token);
            await Task.Delay(5000, token);
        }

        logger.LogInformation("Loop cancelled.");
    }

    private async Task expensiveTask(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 10; i++)
        {
            logger.LogInformation("Computing..{}", i);
            await Task.Delay(1000, cancellationToken);
        }
    }
    //
    // private void loopInBackground(object state)
    // {
    //     var cancellationToken = (CancellationToken)state;
    //
    //     if (!cancellationToken.IsCancellationRequested)
    //     {
    //         logger.LogInformation("Sleeping..");
    //     }
    //     else
    //     {
    //         logger.LogInformation("CANCELING!!!!");
    //     }
    // }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _loopTask;
    }

    private void OnStarted()
    {
        logger.LogInformation("OnStarted has been called.");

        // Perform post-startup activities here
    }

    private void OnStopping()
    {
        logger.LogInformation("OnStopping has been called.");

        // Perform on-stopping activities here
    }

    private void OnStopped()
    {
        logger.LogInformation("OnStopped has been called.");

        // Perform post-stopped activities here
    }
}