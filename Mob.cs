using System;

namespace EternityRPG
{
    public class Mob : Enemy
    {
        public Mob(int typeOfEnemy) => CreateEnemy(typeOfEnemy);

        private void CreateEnemy(int typeOfEnemy)
        {
            switch (typeOfEnemy)
            {
                case 1:
                    Name = "Stinky rat";
                    Health = 20;
                    CurrentHealth = Health;
                    MinDamage = 4;
                    MaxDamage = 9;
                    Gold = 10;
                    Exp = 25;
                    ChanceToInterruptTheEscape = 10;
                    NormalAttackPhrase = "shoots claws";
                    SpecialAttackPhrase = "hits with two paws at a time";
                    break;

                case 2:
                    Name = "Sticky frog";
                    Health = 40;
                    CurrentHealth = Health;
                    MinDamage = 8;
                    MaxDamage = 13;
                    Gold = 20;
                    Exp = 45;
                    ChanceToInterruptTheEscape = 13;
                    NormalAttackPhrase = "attacks with a vile tongue";
                    SpecialAttackPhrase = "shoots out toxin";
                    break;

                case 3:
                    Name = "Poison ivy";
                    Health = 70;
                    CurrentHealth = Health;
                    MinDamage = 12;
                    MaxDamage = 17;
                    Gold = 35;
                    Exp = 60;
                    ChanceToInterruptTheEscape = 16;
                    NormalAttackPhrase = "sprinkles with poisonous mucus";
                    SpecialAttackPhrase = "tightly grips with ivy";
                    break;

                case 4:
                    Name = "Bloody bat";
                    Health = 100;
                    CurrentHealth = Health;
                    MinDamage = 16;
                    MaxDamage = 21;
                    Gold = 50;
                    Exp = 80;
                    ChanceToInterruptTheEscape = 20;
                    NormalAttackPhrase = "bites the body with its teeth";
                    SpecialAttackPhrase = "ripping apart the armor with claws";
                    break;

                case 5:
                    Name = "Dark whisperer";
                    Health = 130;
                    CurrentHealth = Health;
                    MinDamage = 20;
                    MaxDamage = 25;
                    Gold = 70;
                    Exp = 100;
                    ChanceToInterruptTheEscape = 23;
                    NormalAttackPhrase = "releases a psychedelic wave";
                    SpecialAttackPhrase = "compresses your insides with darkness";
                    break;

                case 6:
                    Name = "Goblin";
                    Health = 160;
                    CurrentHealth = Health;
                    MinDamage = 24;
                    MaxDamage = 29;
                    Gold = 85;
                    Exp = 135;
                    ChanceToInterruptTheEscape = 26;
                    NormalAttackPhrase = "hits with a terrifying mace";
                    SpecialAttackPhrase = "strikes with two paws";
                    break;

                case 7:
                    Name = "Fire thorn";
                    Health = 250;
                    CurrentHealth = Health;
                    MinDamage = 28;
                    MaxDamage = 33;
                    Gold = 100;
                    Exp = 150;
                    ChanceToInterruptTheEscape = 30;
                    NormalAttackPhrase = "shoots many spikes";
                    SpecialAttackPhrase = "floods the entire floor with magma";
                    break;

                case 8:
                    Name = "Ork warrior";
                    Health = 300;
                    CurrentHealth = Health;
                    MinDamage = 32;
                    MaxDamage = 37;
                    Gold = 120;
                    Exp = 180;
                    ChanceToInterruptTheEscape = 33;
                    NormalAttackPhrase = "attacks with spear and shield";
                    SpecialAttackPhrase = "throws a shield at your head";
                    break;

                case 9:
                    Name = "Mutant";
                    Health = 340;
                    CurrentHealth = Health;
                    MinDamage = 36;
                    MaxDamage = 41;
                    Gold = 140;
                    Exp = 230;
                    ChanceToInterruptTheEscape = 36;
                    NormalAttackPhrase = "hits with claws from the ground";
                    SpecialAttackPhrase = "summons its copies and beat all together";
                    break;
            }
        }
    }
}
