using System;

namespace EternityRPG
{
    public class boss2 : Enemy
    {
        public boss2()
        {
            Name = "Spiteful golem";
            Health = 3000;
            CurrentHealth = Health;
            MinDamage = 110;
            MaxDamage = 150;
            CritChance = 13;
            Exp = 450;
            Gold = 650;
            IsDead = false;
            CounterToReachTheBoss = random.Next(20, 30);
            ChanceToInterruptTheEscape = 100;
            NormalAttackPhrase = "throws a huge stone";
            SpecialAttackPhrase = "throws many sharp stalactites";
        }
    }
}
