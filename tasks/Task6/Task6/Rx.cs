using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace Task6
{
    class BackGroundwork
    {
        public static void StartBackgroundWork()
        {
            Console.WriteLine("Shows use of Start to start on a background thread:");
            var o = Observable.Start(() =>
            {
            //This starts on a background thread.
            Console.WriteLine("From background thread. Does not block main thread.");
                Console.WriteLine("Calculating...");
                Thread.Sleep(3000);
                Console.WriteLine("Background work completed.");
            }).Finally(() => Console.WriteLine("Main thread completed."));
            Console.WriteLine("\r\n\t In Main Thread...\r\n");
            o.Wait();   // Wait for completion of background operation.
        }

    }


}
