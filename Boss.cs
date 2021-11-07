namespace EternityRPG
{
    class Boss : Enemy
    {
        public Boss(int bossType) => CreateBoss(bossType);

        private void CreateBoss(int bossType)
        {
            switch (bossType)
            { 
                case 1:
                    Name = "Evil forest spirit";
                    MaxHP = 2000;
                    HP = MaxHP;
                    MinDamage = 60;
                    MaxDamage = 100;
                    CritChance = 10;
                    Exp = 250;
                    Gold = 450;
                    CounterToReachTheBoss = random.Next(15, 25);
                    ChanceToInterruptTheEscape = 100;
                    NormalAttackPhrase = "strikes with a branch";
                    CriticalAttackPhrase = "brings a tree down on you";
                    break;

                case 2:
                    Name = "Spiteful golem";
                    MaxHP = 3000;
                    HP = MaxHP;
                    MinDamage = 100;
                    MaxDamage = 140;
                    CritChance = 13;
                    Exp = 450;
                    Gold = 650;
                    CounterToReachTheBoss = random.Next(20, 30);
                    ChanceToInterruptTheEscape = 100;
                    NormalAttackPhrase = "throws a huge stone";
                    CriticalAttackPhrase = "throws many sharp stalactites";
                    break;

                case 3:
                    Name = "Fire dragon";
                    MaxHP = 4000;
                    HP = MaxHP;
                    MinDamage = 140;
                    MaxDamage = 180;
                    CritChance = 16;
                    Exp = 650;
                    Gold = 850;
                    CounterToReachTheBoss = random.Next(25, 35);
                    ChanceToInterruptTheEscape = 100;
                    NormalAttackPhrase = "attacks with fire breath";
                    CriticalAttackPhrase = "grabs you and pushes you into the fire";
                    break;

                case 4:
                    Name = "Descendant of the fallen gods";
                    MaxHP = 8000;
                    HP = MaxHP;
                    MinDamage = 180;
                    MaxDamage = 250;
                    CritChance = 20;
                    Exp = 999;
                    Gold = 999;
                    ChanceToInterruptTheEscape = 100;
                    NormalAttackPhrase = "pierces with the sword of darkness";
                    CriticalAttackPhrase = "devours you with darkness from within";
                    break;
            }
        }
    }
}
