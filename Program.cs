using System;
using System.Collections.Generic;
using System.Linq;

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

            Random randInt = new Random();

            Bank bank1 = new Bank()
            {
                AlarmScore = randInt.Next(0, 100),
                VaultScore = randInt.Next(0, 100),
                SecurityGuardScore = randInt.Next(0, 100),
                CashOnHand = randInt.Next(50000, 1000000)
            };

            Dictionary<string, int> systemList = new Dictionary<string, int>()
        {
            {"Alarm", bank1.AlarmScore},
            {"Vault",bank1.VaultScore},
            {"Security Guard",bank1.SecurityGuardScore}
        };

            var SortedDict = from entry in systemList orderby entry.Value ascending select entry;

            Console.WriteLine($"Least Secure : {SortedDict.ElementAt(0).Key}");
            Console.WriteLine($"Most Secure : {SortedDict.ElementAt(2).Key}");

            for (int i = 0; i < rolodex.Count; i++)
            {
                Console.WriteLine($"{i}. {rolodex[i].Name}:  ");
                Console.WriteLine($"    Speciality: {rolodex[i].GetType().ToString().Split('.')[1]}");
                Console.WriteLine($"    Skill Level: {rolodex[i].SkillLevel}");
                Console.WriteLine($"    Skill Level: {rolodex[i].PercentageCut}%");
            }

            List<IRobber> crew = new List<IRobber>();
            string output = "value";
            while (output != "")
            {
                Console.Write("Enter the number of the operative you want to include in the heist:");
                output = Console.ReadLine();
                if (output == "") { continue; }
                int num = int.Parse(output);
                List<IRobber> filtered = rolodex.Where(r => !crew.Contains(r) && r.PercentageCut < 100 - crew.Select(s => s.PercentageCut).Sum()).ToList();
                if (filtered.Contains(rolodex[num]))
                {
                    crew.Add(rolodex[num]);
                    Console.WriteLine("Operative successfully added!:)");
                }
                else
                {
                    Console.WriteLine("Operative is already included!:)");
                }
            }
            foreach (IRobber robber in crew)
            {
                robber.PerformSkill(bank1);
            };

            if (bank1.IsSecure)
            {
                Console.WriteLine("Unsuccessful Heist!!!");
            }
            else
            {
                Console.WriteLine("Successful Heist!!!");

                foreach (IRobber robber in crew)
                {
                    Console.WriteLine($"{robber.Name} gets {(robber.PercentageCut * .01) * bank1.CashOnHand}");
                }
            }
        }
    }
}

