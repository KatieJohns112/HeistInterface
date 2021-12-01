using System;
using System.Collections.Generic;

namespace HeistInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Hacker robber1 = new Hacker();
            Muscle muscle1 = new Muscle();
            LockSpecialist specialist1 = new LockSpecialist();
            Hacker robber2 = new Hacker();
            Muscle muscle2 = new Muscle();
            LockSpecialist specialist2 = new LockSpecialist();

            List<IRobber> rolodex = new List<IRobber>()
            {
                robber1, muscle1, specialist1, robber2, muscle2, specialist2
            };
        }
    }
}
