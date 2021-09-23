using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstRPG
{
    public class Player : GameCharacter
    {
        public int Lvl { get; set; } = 1;
        private int PlayerType { get; set; }
        private string PlayerClass { get; set; }
        public double LowDamage { get; set; }
        public double HighDamage { get; set; }

        public Player(int playerType, string name)
        {
            PlayerType = playerType;
            Name = name;
            Gold = 0;
            Exp = 0;
            CreatePlayer();
        }

        private void CreatePlayer()
        {
            switch (PlayerType)
            {
                case 1:
                    PlayerClass = "warrior";
                    Health = 200;
                    CurrentHealth = Health;
                    LowDamage = 3;
                    HighDamage = 6;
                    break;

                case 2:
                    PlayerClass = "archer";
                    Health = 160;
                    CurrentHealth = Health;
                    LowDamage = 4;
                    HighDamage = 7;
                    break;

                case 3:
                    PlayerClass = "mage";
                    Health = 120;
                    CurrentHealth = Health;
                    LowDamage = 5;
                    HighDamage = 8;
                    break;
            }
        }

        public double GenerateDamage()
        {
            switch (PlayerType)
            {
                case 1:
                    //warrior
                    Damage = random.Next((int)LowDamage, (int)HighDamage);
                    break;

                case 2:
                    //archer
                    Damage = random.Next((int)LowDamage, (int)HighDamage);
                    break;

                case 3:
                    //mage
                    Damage = random.Next((int)LowDamage, (int)HighDamage);
                    break;

            }

            return Damage;
        }

        public void LevelUp(int exp)
        {
            if (Lvl == 1 && exp >= 100) GetLvl();
            if (Lvl == 2 && exp >= 200) GetLvl();
            if (Lvl == 3 && exp >= 400) GetLvl();
            if (Lvl == 4 && exp >= 800) GetLvl();
            if (Lvl == 5 && exp >= 1200) GetLvl();
            if (Lvl == 6 && exp >= 1600) GetLvl();
            if (Lvl == 7 && exp >= 2000) GetLvl();
            if (Lvl == 8 && exp >= 2500) GetLvl();
            if (Lvl == 9 && exp >= 3000) GetLvl();
            if (Lvl == 10 && exp >= 3600) GetLvl();

            void GetLvl()
            {
                Lvl++;
                Health = (int)(((Health / 100) * 20) + Health);
                LowDamage = (int)(((LowDamage / 100) * 20) + LowDamage);
                HighDamage = (int)(((HighDamage / 100) * 20) + HighDamage);
            }
        }
    }
}
