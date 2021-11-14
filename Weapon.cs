using System;
using System.Threading;

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
                Print.Text($"\t\t\t  {Title} purchased and equipped\n", ConsoleColor.DarkCyan);
            }
            else Print.Text("not enough gold".PadLeft(41, ' ') + "\n", ConsoleColor.DarkRed);
            Thread.Sleep(2000);
        }

        public override void Use(Player player, Item[] inventory, int choice)
        {
            //turning all weapon to false before buying new one
            for (int i = 0; i < inventory.Length; i++)
                inventory[i].WeaponIsBought = false;

            //equipping new one
            inventory[choice - 1].WeaponIsBought = true;
        }
    }
}
