using System;

namespace EternityRPG
{
    public class boss3 : Enemy
    {
        public boss3()
        {
            Name = "Fire dragon";
            Health = 4000;
            CurrentHealth = Health;
            MinDamage = 150;
            MaxDamage = 190;
            CritChance = 16;
            Exp = 650;
            Gold = 850;
            IsDead = false;
            CounterToReachTheBoss = random.Next(25, 35);
            ChanceToInterruptTheEscape = 100;
            NormalAttackPhrase = "attacks with fire breath";
            SpecialAttackPhrase = "grabs you and pushes you into the fire";
        }
    }
}
