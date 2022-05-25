using System;

namespace RP.Automation.Core.Utilities
{
    public static class Randomizer
    {
        readonly static Random random = new Random();

        public static int RandomDigits()
        {
            return random.Next(1000000, 9999999);
        }
    }
}
