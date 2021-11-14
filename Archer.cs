namespace EternityRPG
{
    public class Archer : Player
    {
        public Archer(string Name, string Gender, string Class)
        {
            base.Name = Name;
            base.Gender = Gender;
            base.Class = Class;

            //male
            if (Gender == "male")
            {
                MaxHP = 160;
                MinDamage = 10;
                MaxDamage = 15;
                CritChance = 10;
                Luck = 1;
            }
            //female
            else
            {
                MaxHP = 140;
                MinDamage = 8;
                MaxDamage = 13;
                CritChance = 15;
                Luck = 5;
            }
            
            HP = MaxHP;
            Gold = 0;
            Exp = 0;
            NormalAttackPhrase = "shoot an arrow";
            CriticalAttackPhrase = "launches a rain of arrows";
        }
    }
}
