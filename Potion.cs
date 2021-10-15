using System;

namespace EternityRPG
{
    public class Potion : Item
    { 
        public Potion(int healingPower, int cost, string title)
        {
            HealingPower = healingPower;
            Cost = cost;
            Title = title;
        }

        public override void Add(Player player, Item[] inventory, int choice)
        {
            if (player.Gold >= Cost)
            {
                player.Gold -= Cost;
                Amount++;
            }
            else
                Print.Text("not enough gold".PadLeft(41, ' ') + "\n", ConsoleColor.DarkRed);
        }

        public override void Use(Player player, Item[] inventory, int choice)
        {
            player.CurrentHealth += HealingPower;
            Amount--;
        }
    }
}
