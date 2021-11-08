using System;

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
                    Title = "Small healing potion";
                    break;

                case 2:
                    Cost = 95;
                    HealingPower = 200;
                    Title = "Medium healing potion";
                    break;

                case 3:
                    Cost = 190;
                    HealingPower = 400;
                    Title = "Big healing potion";
                    break;
            }
        }

        public override void Buy(Player player, Item[] inventory, int choice)
        {
            if (player.Gold >= Cost)
            {
                player.Gold -= Cost;
                Amount++;
                Print.Text($"\t\t\t  +1 {Title}\n\n", ConsoleColor.DarkGreen);
            }
            else Print.Text("not enough gold".PadLeft(41, ' ') + "\n\n", ConsoleColor.DarkRed);
        }

        public override void Use(Player player, Item[] inventory, int choice)
        {
            player.HP += HealingPower;
            Amount--;
        }
    }
}
