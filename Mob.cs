namespace EternityRPG
{
    public class Mob : Enemy
    {
        public Mob(int enemyType) => CreateEnemy(enemyType);

        private void CreateEnemy(int enemyType)
        {
            switch (enemyType)
            {
                case 1:
                    Name = "Stinky rat";
                    MaxHP = 20;
                    HP = MaxHP;
                    MinDamage = 4;
                    MaxDamage = 9;
                    Gold = 10;
                    Exp = 25;
                    ChanceToInterruptTheEscape = 10;
                    NormalAttackPhrase = "shoots claws";
                    CriticalAttackPhrase = "hits with two paws at a time";
                    break;

                case 2:
                    Name = "Sticky frog";
                    MaxHP = 40;
                    HP = MaxHP;
                    MinDamage = 8;
                    MaxDamage = 13;
                    Gold = 20;
                    Exp = 45;
                    ChanceToInterruptTheEscape = 13;
                    NormalAttackPhrase = "attacks with a vile tongue";
                    CriticalAttackPhrase = "shoots out toxin";
                    break;

                case 3:
                    Name = "Poison ivy";
                    MaxHP = 70;
                    HP = MaxHP;
                    MinDamage = 12;
                    MaxDamage = 17;
                    Gold = 35;
                    Exp = 60;
                    ChanceToInterruptTheEscape = 16;
                    NormalAttackPhrase = "sprinkles with poisonous mucus";
                    CriticalAttackPhrase = "tightly grips with ivy";
                    break;

                case 4:
                    Name = "Bloody bat";
                    MaxHP = 100;
                    HP = MaxHP;
                    MinDamage = 16;
                    MaxDamage = 21;
                    Gold = 50;
                    Exp = 80;
                    ChanceToInterruptTheEscape = 20;
                    NormalAttackPhrase = "bites the body with its teeth";
                    CriticalAttackPhrase = "ripping apart the armor with claws";
                    break;

                case 5:
                    Name = "Dark whisperer";
                    MaxHP = 130;
                    HP = MaxHP;
                    MinDamage = 20;
                    MaxDamage = 25;
                    Gold = 70;
                    Exp = 100;
                    ChanceToInterruptTheEscape = 23;
                    NormalAttackPhrase = "releases a psychedelic wave";
                    CriticalAttackPhrase = "compresses your insides with darkness";
                    break;

                case 6:
                    Name = "Goblin";
                    MaxHP = 160;
                    HP = MaxHP;
                    MinDamage = 24;
                    MaxDamage = 29;
                    Gold = 85;
                    Exp = 135;
                    ChanceToInterruptTheEscape = 26;
                    NormalAttackPhrase = "hits with a terrifying mace";
                    CriticalAttackPhrase = "strikes with two paws";
                    break;

                case 7:
                    Name = "Fire thorn";
                    MaxHP = 250;
                    HP = MaxHP;
                    MinDamage = 28;
                    MaxDamage = 33;
                    Gold = 100;
                    Exp = 150;
                    ChanceToInterruptTheEscape = 30;
                    NormalAttackPhrase = "shoots many spikes";
                    CriticalAttackPhrase = "floods the entire floor with magma";
                    break;

                case 8:
                    Name = "Ork warrior";
                    MaxHP = 300;
                    HP = MaxHP;
                    MinDamage = 32;
                    MaxDamage = 37;
                    Gold = 120;
                    Exp = 180;
                    ChanceToInterruptTheEscape = 33;
                    NormalAttackPhrase = "attacks with spear and shield";
                    CriticalAttackPhrase = "throws a shield at your head";
                    break;

                case 9:
                    Name = "Mutant";
                    MaxHP = 340;
                    HP = MaxHP;
                    MinDamage = 36;
                    MaxDamage = 41;
                    Gold = 140;
                    Exp = 230;
                    ChanceToInterruptTheEscape = 36;
                    NormalAttackPhrase = "hits with claws from the ground";
                    CriticalAttackPhrase = "summons its copies and beat all together";
                    break;
            }
        }
    }
}
