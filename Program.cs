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

            Console.WriteLine("Current Operatives:\n");
            foreach (IRobber robber in rolodex)
            {
                Console.WriteLine($"{robber.Name}");
            }


            Console.Write("Enter a new crew member's name:");
            string crewMember = Console.ReadLine();

            while (crewMember != "")
            {
                Console.WriteLine($"What speciality (Hacker, Muscle or Lock Specialist) should {crewMember} have?");
                string speciality = Console.ReadLine();
                Console.WriteLine($"What skill level (1-100) should this {speciality} have?");
                int skillLevel = int.Parse(Console.ReadLine());
                Console.WriteLine($"What should {crewMember} want as a percentage cut?");
                int percentageCut = int.Parse(Console.ReadLine());
                if (speciality == "Hacker")
                {
                    rolodex.Add(new Hacker()
                    {
                        Name = crewMember,
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut
                    });
                }
                else if (speciality == "Muscle")
                {
                    rolodex.Add(new Muscle()
                    {
                        Name = crewMember,
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut
                    });
                }
                else if (speciality == "Lock Specialist")
                {
                    rolodex.Add(new LockSpecialist()
                    {
                        Name = crewMember,
                        SkillLevel = skillLevel,
                        PercentageCut = percentageCut
                    });
                }
                Console.WriteLine("Enter a new crew member name");
                crewMember = Console.ReadLine();
            }
        }
    }
}

