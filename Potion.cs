using System;
using System.Threading;

namespace EternityRPG
{
    public class Potion : Item
    {
        public Potion(int potionType) => GetPotion(potionType);

        private void GetPotion(int potionType)
        {
            switch (potionType)
            {
                case 1:
                    Cost = 45;
                    HealingPower = 100;
                    Title = "Small";
                    break;

                case 2:
                    Cost = 95;
                    HealingPower = 200;
                    Title = "Medium";
                    break;

                case 3:
                    Cost = 190;
                    HealingPower = 400;
                    Title = "Big";
                    break;
            }
        }

        public override void Buy(Player player, Item[] inventory, int choice)
        {
            if (player.Gold >= Cost)
            {
                player.Gold -= Cost;
                Amount++;
                Print.Text($"\t\t\t  +1 {Title}\n", ConsoleColor.DarkGreen);
            }
            else Print.Text("not enough gold".PadLeft(41, ' ') + "\n", ConsoleColor.DarkRed);
            Thread.Sleep(2000);
        }

        public override void Use(Player player, Item[] inventory, int choice)
        {
            player.HP += HealingPower;
            Amount--;
        }
    }
}
