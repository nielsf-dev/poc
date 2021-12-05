using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // WebClient client = new WebClient();
            // byte[] downloadData = client.DownloadData("https://speed.hetzner.de/100MB.bin");

            Task t =  CallManager.ManageCalls();

            // for (int i = 0; i < 5; i++)
            // {
            //     Debug.WriteLine("Blocks thread");
            //     Thread.Sleep(TimeSpan.FromSeconds(1));
            // }

            //manageCalls.Wait();
            t.Wait();
            Debug.WriteLine("done");
        }
    }
}
