using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstRPG
{
    public class Enemy : GameCharacter
    {
        private int EnemyType { get; set; }

        public Enemy(int enemyType)
        {
            EnemyType = enemyType;
            CreateEnemy();
        }

        private void CreateEnemy()
        {
            switch (EnemyType)
            {
                case 1:
                    Name = "Rat";
                    Health = 20;
                    CurrentHealth = Health;
                    Gold = 5;
                    Exp = 190;//15
                    break;

                case 2:
                    Name = "Ork";
                    Health = 50;
                    CurrentHealth = Health;
                    Gold = 15;
                    Exp = 35;
                    break;

                case 3:
                    Name = "Mutant";
                    Health = 80;
                    CurrentHealth = Health;
                    Gold = 35;
                    Exp = 70;
                    break;
            }
        }

        public int GenerateDamage()
        {
            switch (EnemyType)
            {
                case 1:
                    //rat
                    Damage = random.Next(1, 3);
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
