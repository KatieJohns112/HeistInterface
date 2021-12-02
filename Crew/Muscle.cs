using System;

namespace HeistInterface
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore -= SkillLevel;
            // bank.AlarmScore = bank.AlarmScore - SkillLevel; this is also line12
            Console.WriteLine($"{Name} is beating up the guards. Decreased security by {SkillLevel} points!");
            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has incapaciatated that bozo!");
            }
        }
    }
}