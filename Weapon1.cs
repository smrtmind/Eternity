namespace EternityRPG
{
    public class Weapon1 : Weapon
    {
        public Weapon1(string playerClass) => GetWeapon(playerClass);

        private void GetWeapon(string playerClass)
        {
            switch (playerClass)
            {
                case "warrior":
                    Title = "Dark Sword";
                    Damage = 150;
                    Cost = 6700;
                    break;

                case "archer":
                    Title = "Bloody Bow";
                    Damage = 155;
                    Cost = 6650;
                    break;

                case "mage":
                    Title = "Staff of Light";
                    Damage = 185;
                    Cost = 6900;
                    break;
            }
        }
    }
}
