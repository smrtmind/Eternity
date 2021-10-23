using System;

namespace EternityRPG
{
    public class Enemy : Character
    {
        public int CounterToReachTheBoss { get; protected set; }
        public int ChanceToInterruptTheEscape { get; protected set; }
        public bool IsDead { get; set; }

        public override void Attack(Player player, Enemy enemy, double damage)
        {
            player.HP -= damage;

            if (player.HP <= 0)
            {
                Print.Text($"\t{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text($"{NormalAttackPhrase} deals ");
                Print.Text($"{damage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("died\n");
            }

            else
            {
                Print.Text($"\t{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text($"{NormalAttackPhrase} deals ");
                Print.Text($"{damage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("have ");
                Print.Text($"{player.HP} HP\n\n", ConsoleColor.DarkGreen);
            }
        }

        public override void CriticalAttack(Player player, Enemy enemy, double damage)
        {
            player.HP -= damage *= random.Next(2, 4);

            if (player.HP <= 0)
            {
                Print.Text($"\t{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text($"{CriticalAttackPhrase} deals ");
                Print.Text($"CRITICAL {damage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("died\n");
            }

            else
            {
                Print.Text($"\t{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text($"{CriticalAttackPhrase} deals ");
                Print.Text($"CRITICAL {damage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("have ");
                Print.Text($"{player.HP} HP\n\n", ConsoleColor.DarkGreen);
            }
        }
    }
}
