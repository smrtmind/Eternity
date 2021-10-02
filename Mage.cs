using System;

namespace EternityRPG
{
    public class Mage : Player
    {
        public Mage(string name, string gender)
        {
            Name = name;
            Gender = gender;
            Class = "mage";
            Health = 120;
            CurrentHealth = Health;
            MinDamage = 13;
            MaxDamage = 18;
            CritChance = 10;
            Gold = 0;
            Exp = 0;
            NormalAttackPhrase = "throws a fireball";
            SpecialAttackPhrase = "causes a firestorm";
        }
    }
}
