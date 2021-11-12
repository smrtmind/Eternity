namespace EternityRPG
{
    public class Warrior : Player
    {
        public Warrior(string Name, string Gender, string Class)
        {
            base.Name = Name;
            base.Gender = Gender;
            base.Class = Class;

            //male
            if (Gender == "male")
            {
                MaxHP = 200;
                MinDamage = 7;
                MaxDamage = 12;
                CritChance = 10;
                Luck = 5;
            }
            //female
            else
            {
                MaxHP = 180;
                MinDamage = 5;
                MaxDamage = 10;
                CritChance = 15;
                Luck = 10;
            }

            HP = MaxHP;
            Gold = 0;
            Exp = 0;
            NormalAttackPhrase = "strikes with a sword";
            CriticalAttackPhrase = "cuts with a sword from above";
        }
    }
}
