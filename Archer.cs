namespace EternityRPG
{
    public class Archer : Player
    {
        public Archer(string Name, string Gender, string Class)
        {
            base.Name = Name;
            base.Gender = Gender;
            base.Class = Class;
            MaxHP = 160;
            HP = MaxHP;
            MinDamage = 10;
            MaxDamage = 15;
            CritChance = 10;
            Gold = 0;
            Exp = 0;
            NormalAttackPhrase = "shoot an arrow";
            CriticalAttackPhrase = "launches a rain of arrows";
        }
    }
}
