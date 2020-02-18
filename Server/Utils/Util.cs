using AltV.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiveZ.Utils
{
    public static class Util
    {
        public static int RandomNumber(int max) => new Random().Next(max);
        public static int RandomNumber(int min, int max) => new Random().Next(min, max);

        public static bool CheckThread(string data = "")
        {
            if (Main.MainThreadId != System.Threading.Thread.CurrentThread.ManagedThreadId)
            {
                Alt.Server.LogError(data + " not in the main thread!");
                return false;
            }
            return true;
        }

    }
}
