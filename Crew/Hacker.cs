using System;

namespace HeistInterface
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore -= SkillLevel;
            // bank.AlarmScore = bank.AlarmScore - SkillLevel; this is also line12
            Console.WriteLine($"{Name} is hacking the alarm system. Decreased security by {SkillLevel} points!");

            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm system!");
            }
        }
    }
}