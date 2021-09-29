using System;

namespace EternityRPG
{
    public class Mage : Character
    {
        public Mage(string name, string sex)
        {
            Class = "mage";
            Health = 1200;
            CurrentHealth = Health;
            MinDamage = 13;
            MaxDamage = 18;
            Name = name;
            Sex = sex;
            Gold = 0;
            Exp = 0;
        }

        public override void Turn(Character player, Character[] enemy, double playerDamage, int index)
        {
            if (enemy[index].CurrentHealth <= 0)
            {
                Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("throws a fireball deals ");
                Print.Text($"{playerDamage} DMG", ConsoleColor.DarkGreen);
                Print.Text(", ");
                Print.Text($"{enemy[index].Name} ", ConsoleColor.DarkMagenta);
                Print.Text("died\n");

                if (enemy[index].IsDead)
                {
                    Print.BossVanquished();
                    Print.Text($"\n\tYou have earned {enemy[index].Gold} gold and {enemy[index].Exp} exp\n", ConsoleColor.DarkYellow);
                }

                else
                    Print.Text($"\n\tVICTORY. You have earned {enemy[index].Gold} gold and {enemy[index].Exp} exp\n", ConsoleColor.DarkYellow);
            }

            else
            {
                Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("throws a fireball deals ");
                Print.Text($"{playerDamage} DMG", ConsoleColor.DarkGreen);
                Print.Text(", ");
                Print.Text($"{enemy[index].Name} ", ConsoleColor.DarkMagenta);
                Print.Text("have ");
                Print.Text($"{enemy[index].CurrentHealth} HP\n", ConsoleColor.DarkRed);
            }
        }
    }
}
