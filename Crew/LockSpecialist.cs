using System;

namespace HeistInterface
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.VaultScore -= SkillLevel;
            // bank.AlarmScore = bank.AlarmScore - SkillLevel; this is also line12
            Console.WriteLine($"{Name} is cracking the vault. Decreased security by{SkillLevel} points!");
            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has opened the vault!");
            }
        }
    }
}