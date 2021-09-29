namespace EternityRPG
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
                    Damage1 = 90;
                    Cost1 = 3100;
                    Weapon2 = "Dark Sword";
                    Damage2 = 150;
                    Cost2 = 6700;
                    break;

                case 2: //archer
                    Weapon1 = "Poisoned Bow";
                    Damage1 = 80;
                    Cost1 = 3200;
                    Weapon2 = "Bloody Bow";
                    Damage2 = 155;
                    Cost2 = 6650;
                    break;

                case 3: //mage
                    Weapon1 = "Staff of Pain";
                    Damage1 = 700000;//70
                    Cost1 = 50;//3050
                    Weapon2 = "Staff of Light";
                    Damage2 = 185;
                    Cost2 = 6900;
                    break;
            }
        }
    }
}
