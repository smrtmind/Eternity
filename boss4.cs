using System;

namespace EternityRPG
{
    public class boss4 : Enemy
    {
        public boss4()
        {
            Name = "Descendant of the fallen gods";
            Health = 8000;
            CurrentHealth = Health;
            MinDamage = 180;
            MaxDamage = 250;
            CritChance = 20;
            Exp = 999;
            Gold = 999;
            IsDead = false;
            ChanceToInterruptTheEscape = 100;
            NormalAttackPhrase = "pierces with the sword of darkness";
            SpecialAttackPhrase = "devours you with darkness from within";
        }
    }
}
