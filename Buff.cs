﻿using System;
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
                    DurationOfEffect = 7;
                    BuffPower = 30;
                    Title = "Small";
                    break;

                case 2:
                    Cost = 235;
                    DurationOfEffect = 5;
                    BuffPower = 70;
                    Title = "Average";
                    break;

                case 3:
                    Cost = 390;
                    DurationOfEffect = 3;
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
            //turning all elixirs to false before buying new one
            for (int i = 0; i < inventory.Length; i++)
                inventory[i].BuffIsActive = false;

            //using new one
            inventory[choice + AmountOfBuffs() - 1].BuffIsActive = true;
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
