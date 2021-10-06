namespace EternityRPG
{
    public class Archer : Player
    {
        public Archer(string Name, string Gender, string Class)
        {
            base.Name = Name;
            base.Gender = Gender;
            base.Class = Class;
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
