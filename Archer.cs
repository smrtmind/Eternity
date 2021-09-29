using System;

namespace EternityRPG
{
    public class Archer : Character
    {
        public Archer(string name, string sex)
        {
            Class = "archer";
            Health = 160;
            CurrentHealth = Health;
            MinDamage = 10;
            MaxDamage = 15;
            Name = name;
            Sex = sex;
            Gold = 0;
            Exp = 0;
        }

        public override void Turn(Character player, Character[] boss, double playerDamage)
        {
            if (boss[Program.index].CurrentHealth <= 0)
            {
                Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("shoot an arrow deals ");
                Print.Text($"{playerDamage} DMG", ConsoleColor.DarkGreen);
                Print.Text(", ");
                Print.Text($"{boss[Program.index].Name} ", ConsoleColor.DarkMagenta);
                Print.Text("died\n");
                Print.BossVanquished();
                Print.Text($"\n\tYou have earned {boss[Program.index].Gold} gold and {boss[Program.index].Exp} exp\n", ConsoleColor.DarkYellow);
            }

            else
            {
                Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("shoot an arrow deals ");
                Print.Text($"{playerDamage} DMG", ConsoleColor.DarkGreen);
                Print.Text(", ");
                Print.Text($"{boss[Program.index].Name} ", ConsoleColor.DarkMagenta);
                Print.Text("have ");
                Print.Text($"{boss[Program.index].CurrentHealth} HP\n", ConsoleColor.DarkRed);
            }
        }
    }
}
