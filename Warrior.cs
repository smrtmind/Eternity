using System;

namespace EternityRPG
{
    public class Warrior : Player
    {
        public Warrior(string name, string gender)
        {
            Name = name;
            Gender = gender;
            Class = "knight";
            Health = 200;
            CurrentHealth = Health;
            MinDamage = 7;
            MaxDamage = 12;
            CritChance = 10;
            Gold = 0;
            Exp = 0;
            NormalAttackPhrase = "strikes with a sword";
            SpecialAttackPhrase = "cuts with a sword from above";
        }
    }
}
