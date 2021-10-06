namespace EternityRPG
{
    public class Mage : Player
    {
        public Mage(string Name, string Gender, string Class)
        {
            base.Name = Name;
            base.Gender = Gender;
            base.Class = Class;
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
