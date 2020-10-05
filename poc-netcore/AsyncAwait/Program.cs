using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitApp
{
    class Program
    {
        static void Main(string[] args)
        {
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
