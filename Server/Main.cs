using AltV.Net.Async;
using System;

namespace FiveZ
{
    class Main : AsyncResource
    {
        public override void OnStart()
        {
            Console.WriteLine("Loading FiveZ Server...");
        }

        public override void OnStop()
        {
            Console.WriteLine("Stopping FiveZ Server...");
        }
    }
}
