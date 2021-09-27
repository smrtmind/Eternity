using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstRPG
{
    public class Boss : GameCharacter
    {
        public int CounterToReachTheBoss { get; set; }
        public bool IsDead { get; set; } = false;

        public Boss() { }

        public Boss(int typeOfCharacter)
        {
            TypeOfCharacter = typeOfCharacter;
            CreateBoss();
        }

        private void CreateBoss()
        {
            switch (TypeOfCharacter)
            {
                case 1:
                    Name = "Evil forest spirit";
                    Health = 2000;
                    CurrentHealth = Health;
                    Exp = 300;
                    Gold = 450;
                    ChanceToInterruptTheEscape = 100;
                    CounterToReachTheBoss = 20;
                    break;

                case 2:
                    Name = "Spiteful golem";
                    Health = 3000;
                    CurrentHealth = Health;
                    Exp = 500;
                    Gold = 700;
                    ChanceToInterruptTheEscape = 100;
                    CounterToReachTheBoss = 25;
                    break;

                case 3:
                    Name = "Fire dragon";
                    Health = 4000;
                    CurrentHealth = Health;
                    Exp = 700;
                    Gold = 900;
                    ChanceToInterruptTheEscape = 100;
                    CounterToReachTheBoss = 30;
                    break;

                case 4:
                    Name = "Descendant of the fallen gods";
                    Health = 8000;
                    CurrentHealth = Health;
                    Exp = 999;
                    Gold = 999;
                    ChanceToInterruptTheEscape = 100;
                    break;
            }
        }

        public double GenerateDamage()
        {
            switch (TypeOfCharacter)
            {
                case 1:
                    //rat
                    Damage = random.Next(70, 100);
                    break;

                case 2:
                    //ork
                    Damage = random.Next(100, 130);
                    break;

                case 3:
                    //mutant
                    Damage = random.Next(130, 160);
                    break;

                case 4:
                    //mutant
                    Damage = random.Next(160, 200);
                    break;

            }

            return Damage;
        }
    }
}
