using System;

namespace EternityRPG
{
    public class Archer : Player
    {
        public Archer(string name, string gender)
        {
            Name = name;
            Gender = gender;
            Class = "archer";
            Health = 160;
            CurrentHealth = Health;
            MinDamage = 10;
            MaxDamage = 15;
            CritChance = 10;
            Gold = 0;
            Exp = 0;
            NormalAttackPhrase = "shoot an arrow";
            SpecialAttackPhrase = "launches a rain of arrows";
        }
    }
}
