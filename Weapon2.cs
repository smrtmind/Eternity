namespace EternityRPG
{
    public class Weapon2 : Weapon
    {
        public Weapon2(string playerClass) => GetWeapon(playerClass);

        private void GetWeapon(string playerClass)
        {
            switch (playerClass)
            {
                case "warrior":
                    Title = "Crystal Sword";
                    Damage = 90;
                    Cost = 3100;
                    break;

                case "archer":
                    Title = "Poisoned Bow";
                    Damage = 80;
                    Cost = 3200;
                    break;

                case "mage":
                    Title = "Staff of Pain";
                    Damage = 70;
                    Cost = 3;// 3050;
                    break;
            }
        }
    }
}
