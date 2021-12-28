namespace EternityRPG
{
    public class Mage : Player
    {
        public Mage(string Name, string Gender, string Class)
        {
            base.Name = Name;
            base.Gender = Gender;
            base.Class = Class;
            
            //male
            if (Gender == "male")
            {
                MaxHP = 120;
                MinDamage = 13;
                MaxDamage = 18;
                CritChance = 5;
                Luck = 1;
            }  
            //female
            else
            {
                MaxHP = 100;
                MinDamage = 11;
                MaxDamage = 16;
                CritChance = 10;
                Luck = 5;
            }

            HP = MaxHP;        
            Gold = 100000;
            Exp = 0;
            NormalAttackPhrase = "throws a fireball";
            CriticalAttackPhrase = "causes a firestorm";
        }
    }
}
