using System;
using System.Collections.Generic;
using System.Text;

namespace FiveZ.Utils
{
    public static class Util
    {
        public static int RandomNumber(int max) => new Random().Next(max);
        public static int RandomNumber(int min, int max) => new Random().Next(min, max);
    }
}
