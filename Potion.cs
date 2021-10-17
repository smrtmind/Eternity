using System;

namespace EternityRPG
{
    public class Potion : Item
    { 
        public Potion(int cost, int healingPower, string title)
        {
            Cost = cost;
            HealingPower = healingPower;
            Title = title;
        }

        public override void Buy(Player player, Item[] inventory, int choice)
        {
            if (player.Gold >= Cost)
            {
                player.Gold -= Cost;
                Amount++;
                Print.Text("\n");
            }
            else Print.Text("not enough gold".PadLeft(41, ' ') + "\n\n", ConsoleColor.DarkRed);
        }

        public override void Use(Player player, Item[] inventory, int choice)
        {
            player.CurrentHealth += HealingPower;
            Amount--;
        }
    }
}
