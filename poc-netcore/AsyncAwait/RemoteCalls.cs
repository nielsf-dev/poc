using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncAwaitApp
{
    public interface IRemoteCalls
    {
        Task ThisTakesAWhile();
        Task ThisTakesAWhile2();
        Task LongCall();
    }

    public class RemoteCalls : IRemoteCalls
    {
        public async Task ThisTakesAWhile()
        {
            Debug.WriteLine("before the call");
            await LongCall();
            Debug.WriteLine("after the call");

            //return 1;
        }
        public Task ThisTakesAWhile2()
        {
            Debug.WriteLine("before the call2");
            var task = LongCall();
            Debug.WriteLine("after the call2");

            return task;
        }

        public async Task LongCall()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }
}