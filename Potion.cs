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
                    Title = "Light bandage";
                    break;

                case 2:
                    Cost = 95;
                    HealingPower = 200;
                    Title = "Pain reliever";
                    break;

                case 3:
                    Cost = 190;
                    HealingPower = 400;
                    Title = "Strong aid kit";
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
            Thread.Sleep(1500);
        }

        public override void Use(Player player, Item[] inventory, int choice)
        {
            player.HP += HealingPower;
            Amount--;
        }

        public static int AmountOfPotions()
        {
            int amountOfPotions = default;

            for (int i = 0; i < Game.inventory.Length; i++)
                if (Game.inventory[i] is Potion)
                    amountOfPotions++;

            return amountOfPotions;
        }
    }
}
