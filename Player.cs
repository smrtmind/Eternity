using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstRPG
{
    public class Player : GameCharacter
    {
        public int PlayerType { get; set; }
        public string PlayerClass { get; set; }    

        public Player() { }

        public Player(int playerType, string name)
        {
            PlayerType = playerType;

            switch (PlayerType)
            {
                case 1:
                    Name = name;
                    PlayerClass = "warrior";
                    Health = 200;
                    CurrentHealth = Health;
                    Damage = random.Next(1, 4);
                    break;

                case 2:
                    Name = name;
                    PlayerClass = "archer";
                    Health = 160;
                    CurrentHealth = Health;
                    Damage = random.Next(2, 5);
                    break;

                case 3:
                    Name = name;
                    PlayerClass = "mage";
                    Health = 120;
                    CurrentHealth = Health;
                    Damage = random.Next(3, 6);
                    break;
            }
        }

        public Player(int playerType, string name, int currentHealth) : this (playerType, name)
        {
            switch (PlayerType)
            {
                case 1:
                    PlayerClass = "warrior";
                    Health = 200;
                    CurrentHealth = currentHealth;
                    Damage = random.Next(1, 4);
                    break;

                case 2:
                    PlayerClass = "archer";
                    Health = 160;
                    CurrentHealth = currentHealth;
                    Damage = random.Next(2, 5);
                    break;

                case 3:
                    PlayerClass = "mage";
                    Health = 120;
                    CurrentHealth = currentHealth;
                    Damage = random.Next(3, 6);
                    break;
            }
        }
    }
}
