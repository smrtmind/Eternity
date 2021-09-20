using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstRPG
{
    public class Player
    {
        public string Name { get; set; }
        public string HeroClass { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int LvlOfPower { get; set; }

        public Player() { }

        public Player(string classOfHero, int maxHealth, int lvlOfPower, string name = "Sam")
        {
            HeroClass = classOfHero;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            LvlOfPower = lvlOfPower;
            Name = name;
        }
    }
}
