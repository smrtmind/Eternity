using System;
using System.Threading;

namespace EternityRPG
{
    public class Buff : Item
    {
        public Buff(int buffType) => GetBuff(buffType);

        private void GetBuff(int buffType)
        {
            switch (buffType)
            {
                case 1:
                    Cost = 110;
                    MaxDurationOfEffect = 7;
                    CurrentDurationOfEffect = MaxDurationOfEffect;
                    BuffPower = 30;
                    Title = "Small";
                    break;

                case 2:
                    Cost = 235;
                    MaxDurationOfEffect = 5;
                    CurrentDurationOfEffect = MaxDurationOfEffect;
                    BuffPower = 70;
                    Title = "Average";
                    break;

                case 3:
                    Cost = 390;
                    MaxDurationOfEffect = 3;
                    CurrentDurationOfEffect = MaxDurationOfEffect;
                    BuffPower = 200;
                    Title = "Huge";
                    break;
            }
        }

        public override void Buy(Player player, Item[] inventory, int choice)
        {
            if (player.Gold >= Cost)
            {
                player.Gold -= Cost;
                Amount++;
                Print.Text($"\t\t\t  +1 {Title} elixir of strength\n", ConsoleColor.DarkGreen);
            }
            else Print.Text("not enough gold".PadLeft(41, ' ') + "\n", ConsoleColor.DarkRed);
            Thread.Sleep(1500);
        }

        public override void Use(Player player, Item[] inventory, int choice)
        {
            int x = choice + AmountOfBuffs() - 1;

            //turning all elixirs to false before buying new one
            for (int i = 0; i < inventory.Length; i++)
                inventory[i].BuffIsActive = false;

            //using new one
            inventory[x].BuffIsActive = true;
            inventory[x].CurrentDurationOfEffect = Game.inventory[x].MaxDurationOfEffect;
            Amount--;
        }

        public static int AmountOfBuffs()
        {
            int amountOfBuffs = default;

            for (int i = 0; i < Game.inventory.Length; i++)
                if (Game.inventory[i] is Buff)
                    amountOfBuffs++;

            return amountOfBuffs;
        }
    }
}
