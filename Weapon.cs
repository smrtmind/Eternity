using System;

namespace EternityRPG
{
    public class Weapon : Item
    {
        public Weapon(string playerClass, int weaponType) => GetWeapon(playerClass, weaponType);

        private void GetWeapon(string playerClass, int weaponType)
        {
            if (weaponType == 1)
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
                        Cost = 3050;
                        break;
                }
            }

            if (weaponType == 2)
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

        public override void Buy(Player player, Item[] inventory, int choice)
        {
            if (player.Gold >= Cost)
            {
                player.Gold -= Cost;
                Use(player, inventory, choice);
                Print.Text($"\t\t\t  {Title} purchased and equipped\n\n", ConsoleColor.DarkCyan);
            }
            else Print.Text("not enough gold".PadLeft(41, ' ') + "\n\n", ConsoleColor.DarkRed);
        }

        public override void Use(Player player, Item[] inventory, int choice)
        {
            if (choice == 4)
            {
                inventory[3].WeaponIsBought = true;
                inventory[4].WeaponIsBought = false;
            }
            if (choice == 5)
            {
                inventory[3].WeaponIsBought = false;
                inventory[4].WeaponIsBought = true;
            }
        }
    }
}
