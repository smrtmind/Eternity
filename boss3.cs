using System;

namespace EternityRPG
{
    public class boss3 : Character
    {
        public boss3()
        {
            Name = "Fire dragon";
            Health = 4000;
            CurrentHealth = Health;
            MinDamage = 130;
            MaxDamage = 160;
            Exp = 700;
            Gold = 900;
            IsDead = false;
            CounterToReachTheBoss = 3;
            ChanceToInterruptTheEscape = 100;
        }

        public override void Turn(Character player, Character[] boss, double bossDamage)
        {
            if (player.CurrentHealth <= 0)
            {
                Print.Text($"\t{boss[Program.index].Name} ", ConsoleColor.DarkMagenta);
                Print.Text("attacks with fire breath, deals ");
                Print.Text($"{bossDamage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("died\n");
            }

            else
            {
                Print.Text($"\t{boss[Program.index].Name} ", ConsoleColor.DarkMagenta);
                Print.Text("attacks with fire breath, deals ");
                Print.Text($"{bossDamage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("have ");
                Print.Text($"{player.CurrentHealth} HP\n\n", ConsoleColor.DarkGreen);
            }
        }
    }
}
