﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncAwaitApp
{
    public class CallManager
    {
        public static async void ManageCalls()
        {
            Debug.WriteLine("Managing calls..");
            //   Task<int> thisTakesAWhile = RemoteCalls.ThisTakesAWhile();
            var remoteCalls = new RemoteCalls();
            await remoteCalls.ThisTakesAWhile();
            await remoteCalls.ThisTakesAWhile();
            //await remoteCalls.ThisTakesAWhile();

            // for (int i = 0; i < 5; i++)
            // {
            //     Debug.WriteLine("Doing DURING the long call!");
            //     await Task.Delay(TimeSpan.FromSeconds(1));
            // }


            //      thisTakesAWhile.Wait();
            //Debug.WriteLine("Done managing calls! The long awaited result is " + thisTakesAWhile.Result);
        }
    }
}