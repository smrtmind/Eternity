using System;

namespace EternityRPG
{
    public class boss1 : Enemy
    {
        public boss1()
        {
            Name = "Evil forest spirit";
            Health = 2000;
            CurrentHealth = Health;
            MinDamage = 70;
            MaxDamage = 110;
            CritChance = 10;
            Exp = 250;
            Gold = 450;
            IsDead = false;
            CounterToReachTheBoss = random.Next(15, 25);
            ChanceToInterruptTheEscape = 100;
            NormalAttackPhrase = "strikes with a branch";
            SpecialAttackPhrase = "brings a tree down on you";
        }
    }
}
