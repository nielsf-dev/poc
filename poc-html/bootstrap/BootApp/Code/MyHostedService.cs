using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BootApp.Code;

internal class MyHostedService : IHostedService
{
    private readonly ILogger logger;
    private readonly IHostApplicationLifetime appLifetime;
    private Timer timer;
    private Task _loopTask;
    private bool cancelled;
    private CancellationTokenSource _stoppingCts;

    public MyHostedService(ILogger<MyHostedService> logger, IHostApplicationLifetime appLifetime)
    {
        this.logger = logger;
        this.appLifetime = appLifetime;
        cancelled = false;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        appLifetime.ApplicationStarted.Register(OnStarted);
        appLifetime.ApplicationStopping.Register(OnStopping);
        appLifetime.ApplicationStopped.Register(OnStopped);

        //_loopTask = loopAwait(cancellationToken);

        _stoppingCts = new CancellationTokenSource();
        _loopTask = loopAwait(_stoppingCts.Token);

        // Thread.Sleep(TimeSpan.FromSeconds(2));
        // _stoppingCts.Cancel();

        // return Task.CompletedTask;
        // timer = new Timer(loopInBackground, cancellationToken, 0, 5000);
        return Task.CompletedTask;
    }

    private async Task loopAwait(CancellationToken token)
    {
        try
        {
            while (!token.IsCancellationRequested)
            {
                await expensiveTask(token);
                await Task.Delay(5000, token);
            }
        }
        catch (OperationCanceledException)
        {
            logger.LogInformation("Loop cancelled.");
        }

        logger.LogInformation("Loop cancelled.");
    }

    private async Task expensiveTask(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 10 && !cancellationToken.IsCancellationRequested; i++)
        {
            logger.LogDebug("Computing..{}", i);
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
        _stoppingCts.Cancel();
        // try
        // {
        // Signal cancellation to the executing method
        // }
        // finally
        // {
        //     // Wait until the task completes or the stop token triggers
        //     await Task.WhenAny(_loopTask, Task.Delay(Timeout.Infinite, cancellationToken)).ConfigureAwait(false);
        // }
    }

    private void OnStarted()
    {
        logger.LogInformation("OnStarted has been called.");

        // Perform post-startup activities here
    }

    private void OnStopping()
    {
        _stoppingCts.Cancel();
        logger.LogInformation("OnStopping has been called.");

        // cancelled = true;
        // try
        // {
        //     _loopTask.Wait();
        // }
        // catch (TaskCanceledException ex)
        // {
        //     Debug.WriteLine("cancelled but is ok");
        // }

        // Perform on-stopping activities here
    }

    private void OnStopped()
    {
        _stoppingCts.Cancel();
        logger.LogInformation("OnStopped has been called.");

        // Perform post-stopped activities here
    }
}