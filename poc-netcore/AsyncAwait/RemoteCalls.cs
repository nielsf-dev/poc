using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncAwaitApp
{
    public class RemoteCalls
    {
        public static async Task<int> ThisTakesAWhile()
        {
            Debug.WriteLine("before the call");
            await LongCall();
            Debug.WriteLine("after the call");

            return 1;
        }

        public static async Task LongCall()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }
}