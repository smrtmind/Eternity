using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstRPG
{
    public class Player : GameCharacter
    {
        public string Sex { get; set; }
        public int DefeatedEnemiesOverall { get; set; }
        public int DefeatedBossesOverall { get; set; }
        public int DefeatedEnemiesToFightTheBoss { get; set; }
        public int Lvl { get; set; } = 1;
        public string PlayerClass { get; set; }
        public double LowDamage { get; set; }
        public double HighDamage { get; set; }

        public Player() { }

        public Player(int typeOfCharacter, string name, string sex)
        {
            TypeOfCharacter = typeOfCharacter;
            Name = name;
            Sex = sex;
            Gold = 0;
            Exp = 0;
            CreatePlayer();
        }

        private void CreatePlayer()
        {
            switch (TypeOfCharacter)
            {
                case 1:
                    PlayerClass = "warrior";
                    Health = 200;
                    CurrentHealth = Health;
                    LowDamage = 7;
                    HighDamage = 12;
                    break;

                case 2:
                    PlayerClass = "archer";
                    Health = 160;
                    CurrentHealth = Health;
                    LowDamage = 10;
                    HighDamage = 15;
                    break;

                case 3:
                    PlayerClass = "mage";
                    Health = 120;
                    CurrentHealth = Health;
                    LowDamage = 13;
                    HighDamage = 18;
                    break;
            }
        }

        public double GenerateDamage(Weapon weapon)
        {
            if (!weapon.Weapon1Bought && !weapon.Weapon2Bought)
                Damage = random.Next((int)LowDamage, (int)HighDamage);

            if (weapon.Weapon1Bought)
                Damage = random.Next((int)LowDamage, (int)HighDamage) + weapon.Damage1;

            if (weapon.Weapon2Bought)
                Damage = random.Next((int)LowDamage, (int)HighDamage) + weapon.Damage2;

            return Damage;
        }

        public void LevelUp(int exp)
        {
            if (Lvl == 1 && exp >= 100) LvlUp();
            if (Lvl == 2 && exp >= 200) LvlUp();
            if (Lvl == 3 && exp >= 400) LvlUp();
            if (Lvl == 4 && exp >= 800) LvlUp();
            if (Lvl == 5 && exp >= 1200) LvlUp();
            if (Lvl == 6 && exp >= 1600) LvlUp();
            if (Lvl == 7 && exp >= 2100) LvlUp();
            if (Lvl == 8 && exp >= 2600) LvlUp();
            if (Lvl == 9 && exp >= 3200) LvlUp();
            if (Lvl == 10 && exp >= 3800) LvlUp();
            if (Lvl == 11 && exp >= 4500) LvlUp();
            if (Lvl == 12 && exp >= 5200) LvlUp();
            if (Lvl == 13 && exp >= 6000) LvlUp();
            if (Lvl == 14 && exp >= 6800) LvlUp();
            if (Lvl == 15 && exp >= 7700) LvlUp();
            if (Lvl == 16 && exp >= 8600) LvlUp();
            if (Lvl == 17 && exp >= 9600) LvlUp();
            if (Lvl == 18 && exp >= 10600) LvlUp();
            if (Lvl == 19 && exp >= 11700) LvlUp();
            if (Lvl == 20 && exp >= 12800) LvlUp();
            if (Lvl == 21 && exp >= 14000) LvlUp();
            if (Lvl == 22 && exp >= 15200) LvlUp();
            if (Lvl == 23 && exp >= 16500) LvlUp();
            if (Lvl == 24 && exp >= 17800) LvlUp();
            if (Lvl == 25 && exp >= 19200) LvlUp();
            if (Lvl == 26 && exp >= 20600) LvlUp();
            if (Lvl == 27 && exp >= 22100) LvlUp();
            if (Lvl == 28 && exp >= 23600) LvlUp();
            if (Lvl == 29 && exp >= 25200) LvlUp();

            void LvlUp()
            {
                Lvl++;
                Health = (int)(((Health / 100) * 20) + Health);
                LowDamage = (int)(((LowDamage / 100) * 20) + LowDamage);
                HighDamage = (int)(((HighDamage / 100) * 20) + HighDamage);
            }
        }
    }
}
