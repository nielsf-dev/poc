using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitApp
{
    class Program
    {
        public static void test()
        {
            var tasks = new List<Task<int>>();
            var source = new CancellationTokenSource();
            var token = source.Token;
            int completedIterations = 0;

            for (int n = 0; n <= 19; n++)
                tasks.Add(Task.Run(() => {
                    int iterations = 0;
                    for (int ctr = 1; ctr <= 2000000; ctr++)
                    {
                        token.ThrowIfCancellationRequested();
                        iterations++;
                    }
                    Interlocked.Increment(ref completedIterations);
                    if (completedIterations >= 10)
                        source.Cancel();
                    return iterations;
                }, token));

            Console.WriteLine("Waiting for the first 10 tasks to complete...\n");
            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException)
            {
                Console.WriteLine("Status of tasks:\n");
                Console.WriteLine("{0,10} {1,20} {2,14:N0}", "Task Id",
                    "Status", "Iterations");
                foreach (var t in tasks)
                    Console.WriteLine("{0,10} {1,20} {2,14}",
                        t.Id, t.Status,
                        t.Status != TaskStatus.Canceled ? t.Result.ToString("N0") : "n/a");
            }
        }

        static async Task Main(string[] args)
        {
            // WebClient client = new WebClient();
            // byte[] downloadData = client.DownloadData("https://speed.hetzner.de/100MB.bin");

            //test();
            mytest();

            //await mytest();
        }

        private static void mytest()
        {
            try
            {
                var configuredTaskAwaitable = CallManager.ManageCalls(); //.ConfigureAwait(false);

                // for (int i = 0; i < 10; i++)
                // {
                //     Debug.WriteLine("Blocks thread");
                //     await Task.Delay(TimeSpan.FromSeconds(1));
                // }

                Debug.WriteLine("conjomang");
                Thread.Sleep(1000);

                //manageCalls.Wait();
                //  t.Wait();
                configuredTaskAwaitable.Wait();
                Debug.WriteLine("done");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception = {ex}");
            }
        }
    }
}
