using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternityRPG
{
    public abstract class Player : Character
    {
        public string Gender { get; set; }
        public string Class { get; set; }
        public int Lvl { get; set; } = 1;

        public double GenerateDamage(Weapon weapon)
        {
            if (weapon.Weapon1Bought)
                Damage = random.Next((int)MinDamage, (int)MaxDamage) + weapon.Damage1;

            if (weapon.Weapon2Bought)
                Damage = random.Next((int)MinDamage, (int)MaxDamage) + weapon.Damage2;

            return Damage;
        }

        public void LevelUp(int exp)
        {
            if (Lvl == 1 && exp >= 100) LvlUp();
            if (Lvl == 2 && exp >= 200) LvlUp();
            if (Lvl == 3 && exp >= 400) LvlUp();
            if (Lvl == 4 && exp >= 800) LvlUp();
            if (Lvl == 5 && exp >= 1200) LvlUp();
            if (Lvl == 6 && exp >= 1600) LvlUp();
            if (Lvl == 7 && exp >= 2100) LvlUp();
            if (Lvl == 8 && exp >= 2600) LvlUp();
            if (Lvl == 9 && exp >= 3200) LvlUp();
            if (Lvl == 10 && exp >= 3800) LvlUp();
            if (Lvl == 11 && exp >= 4500) LvlUp();
            if (Lvl == 12 && exp >= 5200) LvlUp();
            if (Lvl == 13 && exp >= 6000) LvlUp();
            if (Lvl == 14 && exp >= 6800) LvlUp();
            if (Lvl == 15 && exp >= 7700) LvlUp();
            if (Lvl == 16 && exp >= 8600) LvlUp();
            if (Lvl == 17 && exp >= 9600) LvlUp();
            if (Lvl == 18 && exp >= 10600) LvlUp();
            if (Lvl == 19 && exp >= 11700) LvlUp();
            if (Lvl == 20 && exp >= 12800) LvlUp();
            if (Lvl == 21 && exp >= 14000) LvlUp();
            if (Lvl == 22 && exp >= 15200) LvlUp();
            if (Lvl == 23 && exp >= 16500) LvlUp();
            if (Lvl == 24 && exp >= 17800) LvlUp();
            if (Lvl == 25 && exp >= 19200) LvlUp();
            if (Lvl == 26 && exp >= 20600) LvlUp();
            if (Lvl == 27 && exp >= 22100) LvlUp();
            if (Lvl == 28 && exp >= 23600) LvlUp();
            if (Lvl == 29 && exp >= 25200) LvlUp();

            void LvlUp()
            {
                Lvl++;
                Health = (int)(((Health / 100) * 10) + Health);
                MinDamage = (int)(((MinDamage / 100) * 10) + MinDamage);
                MaxDamage = (int)(((MaxDamage / 100) * 10) + MaxDamage);
            }
        }

        public override void Attack(Player player, Enemy enemy, double playerDamage)
        {
            enemy.CurrentHealth -= playerDamage;

            if (enemy.CurrentHealth <= 0)
            {
                Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text($"{NormalAttackPhrase} deals ");
                Print.Text($"{playerDamage} DMG", ConsoleColor.DarkGreen);
                Print.Text(", ");
                Print.Text($"{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text("died\n");

                if (enemy.GetType() == typeof(boss1) ||
                    enemy.GetType() == typeof(boss2) ||
                    enemy.GetType() == typeof(boss3) ||
                    enemy.GetType() == typeof(boss4))
                {
                    enemy.IsDead = true;
                    Print.BossVanquished();
                    Print.Text($"\n\tYou have earned {enemy.Gold} gold and {enemy.Exp} exp\n", ConsoleColor.DarkYellow);
                }

                else
                    Print.Text($"\n\tVICTORY. You have earned {enemy.Gold} gold and {enemy.Exp} exp\n", ConsoleColor.DarkYellow);
            }

            else
            {
                Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text($"{NormalAttackPhrase} deals ");
                Print.Text($"{playerDamage} DMG", ConsoleColor.DarkGreen);
                Print.Text(", ");
                Print.Text($"{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text("has ");
                Print.Text($"{enemy.CurrentHealth} HP\n", ConsoleColor.DarkRed);
            }
        }

        public override void SpecialAttack(Player player, Enemy enemy, double playerDamage)
        {
            enemy.CurrentHealth -= playerDamage *= random.Next(2, 4);

            if (enemy.CurrentHealth <= 0)
            {
                Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text($"{SpecialAttackPhrase} deals ");
                Print.Text($"CRITICAL {playerDamage} DMG", ConsoleColor.DarkGreen);
                Print.Text(", ");
                Print.Text($"{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text("died\n");

                if (enemy.GetType() == typeof(boss1) ||
                    enemy.GetType() == typeof(boss2) ||
                    enemy.GetType() == typeof(boss3) ||
                    enemy.GetType() == typeof(boss4))
                {
                    enemy.IsDead = true;
                    Print.BossVanquished();
                    Print.Text($"\n\tYou have earned {enemy.Gold} gold and {enemy.Exp} exp\n", ConsoleColor.DarkYellow);
                }

                else
                    Print.Text($"\n\tVICTORY. You have earned {enemy.Gold} gold and {enemy.Exp} exp\n", ConsoleColor.DarkYellow);
            }

            else
            {
                Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text($"{SpecialAttackPhrase} deals ");
                Print.Text($"CRITICAL {playerDamage} DMG", ConsoleColor.DarkGreen);
                Print.Text(", ");
                Print.Text($"{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text("has ");
                Print.Text($"{enemy.CurrentHealth} HP\n", ConsoleColor.DarkRed);
            }
        }
    }
}
