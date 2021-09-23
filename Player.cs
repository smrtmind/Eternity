using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstRPG
{
    public class Player : GameCharacter
    {
        public int Lvl { get; set; }
        private int PlayerType { get; set; }
        private string PlayerClass { get; set; }

        public Player(int playerType, string name)
        {
            PlayerType = playerType;
            Name = name;
            Gold = 0;
            Exp = 0;
            Lvl = 1;
            GeneratePlayer();
        }

        private void GeneratePlayer()
        {
            switch (PlayerType)
            {
                case 1:
                    PlayerClass = "warrior";
                    Health = 200;
                    CurrentHealth = Health;
                    break;

                case 2:
                    PlayerClass = "archer";
                    Health = 160;
                    CurrentHealth = Health;
                    break;

                case 3:
                    PlayerClass = "mage";
                    Health = 120;
                    CurrentHealth = Health;
                    break;
            }
        }

        public int GenerateDamage()
        {
            switch (PlayerType)
            {
                case 1:
                    //warrior
                    Damage = random.Next(1, 4);
                    break;

                case 2:
                    //archer
                    Damage = random.Next(2, 5);
                    break;

                case 3:
                    //mage
                    Damage = random.Next(3, 6);
                    break;

            }

            return Damage;
        }

        public void LevelUp(int exp)
        {
            if (Lvl == 1 && exp >= 100 && exp < 200) GetLvl();
            if (Lvl == 2 && exp >= 200 && exp < 400) GetLvl();
            if (Lvl == 3 && exp >= 400 && exp < 800) GetLvl();
            if (Lvl == 4 && exp >= 800 && exp < 1200) GetLvl();
            if (Lvl == 5 && exp >= 1200 && exp < 1600) GetLvl();
            if (Lvl == 6 && exp >= 1600 && exp < 2000) GetLvl();
            if (Lvl == 7 && exp >= 2000 && exp < 2500) GetLvl();
            if (Lvl == 8 && exp >= 2500 && exp < 3000) GetLvl();
            if (Lvl == 9 && exp >= 3000 && exp < 3600) GetLvl();
            if (Lvl == 10 && exp >= 3600 && exp < 4200) GetLvl();

            void GetLvl()
            {
                Lvl++;
                Health = (int)(((Health / 100) * 20) + Health);
            }
        }
    }
}
