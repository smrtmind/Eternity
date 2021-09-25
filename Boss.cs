using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstRPG
{
    public class Boss : GameCharacter
    {
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
                    Name = "first boss";
                    Health = 1000;
                    CurrentHealth = Health;
                    Exp = 200;
                    Gold = 200;
                    ChanceToInterruptTheEscape = 100;
                    break;

                case 2:
                    Name = "second boss";
                    Health = 1300;
                    CurrentHealth = Health;
                    Exp = 200;
                    Gold = 200;
                    ChanceToInterruptTheEscape = 100;
                    break;

                case 3:
                    Name = "third boss";
                    Health = 1700;
                    CurrentHealth = Health;
                    Exp = 200;
                    Gold = 200;
                    ChanceToInterruptTheEscape = 100;
                    break;

                case 4:
                    Name = "final boss";
                    Health = 3000;
                    CurrentHealth = Health;
                    Exp = 200;
                    Gold = 200;
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
                    Damage = random.Next(50, 80);
                    break;

                case 2:
                    //ork
                    Damage = random.Next(70, 100);
                    break;

                case 3:
                    //mutant
                    Damage = random.Next(90, 120);
                    break;

                case 4:
                    //mutant
                    Damage = random.Next(120, 150);
                    break;

            }

            return Damage;
        }
    }
}
