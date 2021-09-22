using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstRPG
{
    public class Enemy : GameCharacter
    {
        public int EnemyType { get; set; }

        public Enemy(int enemyType)
        {
            EnemyType = enemyType;

            switch (EnemyType)
            {
                case 1:
                    Name = "Rat";
                    Health = 20;
                    CurrentHealth = Health;
                    Damage = random.Next(1, 3);
                    break;

                case 2:
                    Name = "Ork";
                    Health = 50;
                    CurrentHealth = Health;
                    Damage = random.Next(5, 10);
                    break;

                case 3:
                    Name = "Mutant";
                    Health = 80;
                    CurrentHealth = Health;
                    Damage = random.Next(7, 15);
                    break;
            }
        }

        public Enemy(int enemyType, int currentHealth) : this (enemyType)
        {
            switch (EnemyType)
            {
                case 1:
                    Name = "Rat";
                    Health = 20;
                    CurrentHealth = currentHealth;
                    Damage = random.Next(1, 3);
                    break;

                case 2:
                    Name = "Ork";
                    Health = 50;
                    CurrentHealth = currentHealth;
                    Damage = random.Next(5, 10);
                    break;

                case 3:
                    Name = "Mutant";
                    Health = 80;
                    CurrentHealth = currentHealth;
                    Damage = random.Next(7, 15);
                    break;
            }
        }
    }
}
