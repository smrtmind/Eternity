using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstRPG
{
    public class Player
    {
        public Random random = new Random();
        public string HeroClass { get; set; }
        public int Damage { get; set; }
        public string Name { get; set; }
        public int HeroType { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        public Player() { }

        //public Player(string classOfHero, int maxHealth, int lvlOfPower, string name = "Sam")
        //{
        //    HeroClass = classOfHero;
        //    MaxHealth = maxHealth;
        //    CurrentHealth = maxHealth;
        //    LvlOfPower = lvlOfPower;
        //    Name = name;
        //}

        public Player(int heroType, string name, int health)
        {
            HeroType = heroType;

            switch (HeroType)
            {
                case 1:
                    Name = name;
                    HeroClass = "warrior";
                    MaxHealth = health;
                    CurrentHealth = MaxHealth;
                    Damage = random.Next(1, 4);
                    break;

                case 2:
                    Name = name;
                    HeroClass = "archer";
                    MaxHealth = health;
                    CurrentHealth = MaxHealth;
                    Damage = random.Next(2, 5);
                    break;

                case 3:
                    Name = name;
                    HeroClass = "mage";
                    MaxHealth = health;
                    CurrentHealth = MaxHealth;
                    Damage = random.Next(3, 6);
                    break;
            }
        }

        public Player(int heroType, string name)
        {
            HeroType = heroType;

            switch (HeroType)
            {
                case 1:
                    Name = name;
                    HeroClass = "warrior";
                    MaxHealth = 200;
                    CurrentHealth = MaxHealth;
                    Damage = random.Next(1, 4);
                    break;

                case 2:
                    Name = name;
                    HeroClass = "archer";
                    MaxHealth = 160;
                    CurrentHealth = MaxHealth;
                    Damage = random.Next(2, 5);
                    break;

                case 3:
                    Name = name;
                    HeroClass = "mage";
                    MaxHealth = 120;
                    CurrentHealth = MaxHealth;
                    Damage = random.Next(3, 6);
                    break;
            }
        }
    }
}
