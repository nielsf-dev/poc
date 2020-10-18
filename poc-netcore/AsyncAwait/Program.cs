using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            byte[] downloadData = client.DownloadData("https://speed.hetzner.de/100MB.bin");

            Task manageCalls = CallManager.ManageCalls();

            for (int i = 0; i < 5; i++)
            {
                Debug.WriteLine("Blocks thread");
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            manageCalls.Wait();
            Debug.WriteLine("done");
        }
    }
}
