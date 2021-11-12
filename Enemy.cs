using System;

namespace EternityRPG
{
    public class Enemy : Character
    {
        public int CounterToReachTheBoss { get; protected set; }
        public int ChanceToInterruptTheEscape { get; protected set; }

        public override void Attack(Player player, Enemy enemy, double damage, bool crit = false)
        {
            Print.Text($"\t{enemy.Name} ", ConsoleColor.DarkMagenta);
            if (!crit)
            {
                player.HP -= damage;
                Print.Text($"{NormalAttackPhrase} deals ");
                Print.Text($"{damage} DMG", ConsoleColor.DarkRed);
            }
            else
            {
                player.HP -= damage *= random.Next(2, 4);
                Print.Text($"{CriticalAttackPhrase} deals ");
                Print.Text($"CRITICAL {damage} DMG", ConsoleColor.DarkRed);
            }
            Print.Text(", ");
            Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);

            //if player died
            if (player.HP <= 0)
            {
                player.IsDead = true;
                Print.Text("died\n");
                Print.YouDied();
            }
            //otherwise continue
            else
            {
                Print.Text("have ");
                Print.Text($"{player.HP} HP\n\n", ConsoleColor.DarkGreen);
            }
        }
    }
}
