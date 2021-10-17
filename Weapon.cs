using System;

namespace EternityRPG
{
    public class Weapon : Item
    {
        public override void Buy(Player player, Item[] inventory, int choice)
        {
            if (player.Gold >= Cost)
            {
                player.Gold -= Cost;
                Use(player, inventory, choice);
                Print.Text("\n");
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
