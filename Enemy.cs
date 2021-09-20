using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstRPG
{
    public class Enemy
    {
        public Random random = new Random(); 
        public int Damage { get; set; }
        public string Name { get; private set; }
        public int Health { get; set; }
        public int LvlOfPower { get; set; }
        public int EnemyType { get; set; }

        public Enemy(int enemyType)
        {
            EnemyType = enemyType;

            switch (EnemyType)
            {
                case 1:
                    Name = "Rat";
                    Health = 20;
                    Damage = random.Next(1, 3);
                    break;

                case 2:
                    Name = "Ork";
                    Health = 50;
                    Damage = random.Next(5, 10);
                    break;

                case 3:
                    Name = "Mutant";
                    Health = 80;
                    Damage = random.Next(7, 15);
                    break;
            }
        }

        public Enemy(string name, int health, int lvlOfPower)
        {
            Name = name;
            Health = health;
            LvlOfPower = lvlOfPower;
        }
    }
}
