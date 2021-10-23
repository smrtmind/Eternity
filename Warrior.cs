namespace EternityRPG
{
    public class Warrior : Player
    {
        public Warrior(string Name, string Gender, string Class)
        {
            base.Name = Name;
            base.Gender = Gender;
            base.Class = Class;
            MaxHP = 200;
            HP = MaxHP;
            MinDamage = 7;
            MaxDamage = 12;
            CritChance = 10;
            Gold = 0;
            Exp = 0;
            NormalAttackPhrase = "strikes with a sword";
            CriticalAttackPhrase = "cuts with a sword from above";
        }
    }
}
