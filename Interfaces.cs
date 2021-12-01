using System;

namespace HeistInterface
{
    public interface IRobber
    {
        public int CashOnHand { get; set; }
        int SkillLevel { get; set; }
        int PercentageCut { get; set; }
        void PerformSkill(Bank bank);
    }
}