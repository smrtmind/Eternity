using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstRPG
{
    public class Enemy : GameCharacter
    {
        public Enemy() { }

        public Enemy(int typeOfCharacter)
        {
            TypeOfCharacter = typeOfCharacter;
            CreateEnemy();
        }

        private void CreateEnemy()
        {
            switch (TypeOfCharacter)
            {
                case 1:
                    Name = "Rat";
                    Health = 30;
                    CurrentHealth = Health;
                    Gold = 5;
                    Exp = 15;
                    ChanceToInterruptTheEscape = 20;
                    break;

                case 2:
                    Name = "Ork";
                    Health = 50;
                    CurrentHealth = Health;
                    Gold = 15;
                    Exp = 35;
                    ChanceToInterruptTheEscape = 25;
                    break;

                case 3:
                    Name = "Mutant";
                    Health = 80;
                    CurrentHealth = Health;
                    Gold = 35;
                    Exp = 70;
                    ChanceToInterruptTheEscape = 30;
                    break;
            }
        }

        public double GenerateDamage()
        {
            switch (TypeOfCharacter)
            {
                case 1:
                    //rat
                    Damage = random.Next(2, 5);
                    break;

                case 2:
                    //ork
                    Damage = random.Next(5, 10);
                    break;

                case 3:
                    //mutant
                    Damage = random.Next(7, 15);
                    break;

            }

            return Damage;
        }
    }
}
