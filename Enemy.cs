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
                    Name = "Stinky rat";
                    Health = 20;
                    CurrentHealth = Health;
                    Gold = 10;
                    Exp = 25;
                    ChanceToInterruptTheEscape = 10;
                    break;

                case 2:
                    Name = "Sticky frog";
                    Health = 40;
                    CurrentHealth = Health;
                    Gold = 20;
                    Exp = 45;
                    ChanceToInterruptTheEscape = 13;
                    break;

                case 3:
                    Name = "Poison ivy";
                    Health = 70;
                    CurrentHealth = Health;
                    Gold = 35;
                    Exp = 60;
                    ChanceToInterruptTheEscape = 16;
                    break;

                case 4:
                    Name = "Bloody bat";
                    Health = 100;
                    CurrentHealth = Health;
                    Gold = 50;
                    Exp = 80;
                    ChanceToInterruptTheEscape = 20;
                    break;

                case 5:
                    Name = "Dark whisperer";
                    Health = 130;
                    CurrentHealth = Health;
                    Gold = 70;
                    Exp = 100;
                    ChanceToInterruptTheEscape = 23;
                    break;

                case 6:
                    Name = "Goblin";
                    Health = 160;
                    CurrentHealth = Health;
                    Gold = 85;
                    Exp = 135;
                    ChanceToInterruptTheEscape = 26;
                    break;

                case 7:
                    Name = "Fire thorn";
                    Health = 250;
                    CurrentHealth = Health;
                    Gold = 100;
                    Exp = 150;
                    ChanceToInterruptTheEscape = 30;
                    break;

                case 8:
                    Name = "Ork warrior";
                    Health = 300;
                    CurrentHealth = Health;
                    Gold = 120;
                    Exp = 180;
                    ChanceToInterruptTheEscape = 33;
                    break;

                case 9:
                    Name = "Mutant";
                    Health = 340;
                    CurrentHealth = Health;
                    Gold = 140;
                    Exp = 230;
                    ChanceToInterruptTheEscape = 36;
                    break;
            }
        }

        public double GenerateDamage()
        {
            switch (TypeOfCharacter)
            {
                case 1:
                    //Stinky rat
                    Damage = random.Next(4, 9);
                    break;

                case 2:
                    //Sticky frog
                    Damage = random.Next(8, 13);
                    break;

                case 3:
                    //Poison ivy
                    Damage = random.Next(12, 17);
                    break;

                case 4:
                    //Bloody bat
                    Damage = random.Next(16, 21);
                    break;

                case 5:
                    //Dark whisperer
                    Damage = random.Next(20, 25);
                    break;

                case 6:
                    //Goblin
                    Damage = random.Next(24, 29);
                    break;

                case 7:
                    //Fire thorn
                    Damage = random.Next(28, 33);
                    break;

                case 8:
                    //Ork warrior
                    Damage = random.Next(32, 37);
                    break;

                case 9:
                    //Mutant
                    Damage = random.Next(36, 41);
                    break;

            }

            return Damage;
        }
    }
}
