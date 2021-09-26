using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstRPG
{
    public class Weapon
    {
        public int PlayerClass { get; set; }
        public int Damage1 { get; set; }
        public int Damage2 { get; set; }
        public string Weapon1 { get; set; }
        public string Weapon2 { get; set; }
        public int Cost1 { get; set; }
        public int Cost2 { get; set; }
        public bool Weapon1Bought { get; set; }
        public bool Weapon2Bought { get; set; }

        public Weapon() { }

        public Weapon(int playerClass)
        {
            PlayerClass = playerClass;
            GetWeapon();
        }

        private void GetWeapon()
        {
            switch (PlayerClass)
            {
                case 1: //warrior
                    Weapon1 = "Crystal Sword";
                    Damage1 = 35;
                    Cost1 = 400;
                    Weapon2 = "Dark Sword";
                    Damage2 = 65;
                    Cost2 = 700;
                    break;

                case 2: //archer
                    Weapon1 = "Poisoned Bow";
                    Damage1 = 32;
                    Cost1 = 390;
                    Weapon2 = "Bloody Bow";
                    Damage2 = 62;
                    Cost2 = 690;
                    break;

                case 3: //mage
                    Weapon1 = "Staff of Pain";
                    Damage1 = 30;
                    Cost1 = 360;
                    Weapon2 = "Staff of Light";
                    Damage2 = 60;
                    Cost2 = 670;
                    break;
            }
        }
    }
}
