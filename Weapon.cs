namespace EternityRPG
{
    public class Weapon
    {
        public bool[] WeaponIsBought = new bool[2];
        public string[] Title = new string[2];
        public int[] Damage = new int[2];
        public int[] Cost = new int[2];

        public Weapon(string playerClass) => GetWeapon(playerClass);

        private void GetWeapon(string playerClass)
        {
            switch (playerClass)
            {
                case "warrior":
                    Title[0] = "Crystal Sword";
                    Damage[0] = 90;
                    Cost[0] = 3100;
                    Title[1] = "Dark Sword";
                    Damage[1] = 150;
                    Cost[1] = 6700;
                    break;

                case "archer":
                    Title[0] = "Poisoned Bow";
                    Damage[0] = 80;
                    Cost[0] = 3200;
                    Title[1] = "Bloody Bow";
                    Damage[1] = 155;
                    Cost[1] = 6650;
                    break;

                case "mage":
                    Title[0] = "Staff of Pain";
                    Damage[0] = 70;
                    Cost[0] = 3050;
                    Title[1] = "Staff of Light";
                    Damage[1] = 185;
                    Cost[1] = 6900;
                    break;
            }
        }
    }
}
